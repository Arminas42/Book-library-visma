using Book_Library.Infrastructure;
using Book_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Library.Services
{
    class TakenBookService : ITakenBookService
    {
        ITakenBookData _takenBookData;
        IBookData _bookData;
        public TakenBookService(ITakenBookData takenBookData, IBookData bookData)
        {
            _takenBookData = takenBookData;
            _bookData = bookData;
        }
        public void Create(TakenBook takenBook)
        {
            var takenBooks = _takenBookData.Read();
            var books = _bookData.Read();
            var chosenBook = books.Where(x => x.ISBN == takenBook.bookISBN).FirstOrDefault();
            var IsTaken = takenBooks.Where(x => x.bookISBN == takenBook.bookISBN).FirstOrDefault();
            if (chosenBook == null)
            {
                Console.WriteLine("No such book exists");
            }
            else if (IsTaken != null)
            {
                Console.WriteLine("Book is already taken");
                return;
            }
            else if (takenBook.ToReturn.Date > DateTime.Now.AddDays(61))
            {
                Console.WriteLine("Book cant be taken for longer than two months");
                return;

            }
            else 
            {
                takenBooks.Add(takenBook);
                _takenBookData.Write(takenBooks);
            }
            
        }
        public void Return(string ISBN)
        {
            var takenBooks = _takenBookData.Read();
            var itemToDelete = takenBooks.Where(x => x.bookISBN == ISBN).FirstOrDefault();
            if (itemToDelete == null)
            {
                Console.WriteLine("Wrong ISBN");
                return;
            }
            if(itemToDelete.ToReturn < DateTime.Now.Date)
            {
                Console.WriteLine("Slow reader, huh?");
                takenBooks.Remove(itemToDelete);

            }
            else
            {
                takenBooks.Remove(itemToDelete);
                _takenBookData.Write(takenBooks);

            }
        }

        public bool CanTakeMoreBooks(string person)
        {
            var takenBooks = _takenBookData.Read();
            var personTookBooks = takenBooks.Where(x => x.Person == person).ToList();
            if (personTookBooks.Count < 3)
            {
                return true;
            }
            else return false;
        }
    }
}
