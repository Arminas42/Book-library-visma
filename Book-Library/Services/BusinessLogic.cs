using Book_Library.Infrastructure;
using Book_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Library.Services
{
    public class BusinessLogic : IBusinessLogic
    {
        IBookService _bookService;
        ITakenBookService _takenBookService;
        public BusinessLogic(IBookService bookService, ITakenBookService takenBookService)
        {
            _bookService = bookService;
            _takenBookService = takenBookService;
        }
        public  void Menu()
        {
            Console.WriteLine("Welcome to library");
            Console.WriteLine("List of commands:");
            Console.WriteLine(" 1. Add book");
            Console.WriteLine("2. Take a book");
            Console.WriteLine("3. Return a book");
            Console.WriteLine("4. List of books");
            Console.WriteLine("5. Delete a book");
        }
        public void ListenForCommand()
        {
            while (true)
            {
                Console.WriteLine("Choose a command!");
                Console.Write("Your input:");
                var command = Convert.ToInt32(Console.ReadLine());
                switch (command)
                {
                    case 1:
                        var book = new Book();
                        Console.WriteLine("You chose add book command!");
                        Console.Write("Book ISBN:");
                        book.ISBN = Console.ReadLine();
                        Console.Write("Book name:");
                        book.Name = Console.ReadLine();
                        Console.Write("*FORMAT 2001-01-01* Book was published:");
                        book.PublicationDate = DateTime.Parse(Console.ReadLine());
                        Console.Write("Book author:");
                        book.Author = Console.ReadLine();
                        Console.Write("Book category:");
                        book.Category = Console.ReadLine();
                        Console.Write("Book language:");
                        book.Language = Console.ReadLine();
                        _bookService.AddBook(book);
                        break;
                    case 2:
                        var takenBook = new TakenBook();
                        Console.WriteLine("You chose take a book command!");
                        Console.Write("Book ISBN:");
                        takenBook.bookISBN = Console.ReadLine();
                        Console.Write("Who is taking a book:");
                        takenBook.Person = Console.ReadLine();
                        Console.Write("*INPUT IN DAYS* How many days you will read it:");
                        takenBook.ToReturn = DateTime.Now.Date.AddDays(Convert.ToInt32(Console.ReadLine()));
                        takenBook.WasTaken = DateTime.Now.Date;
                        if (_takenBookService.CanTakeMoreBooks(takenBook.Person) == true) 
                        {
                            _takenBookService.Create(takenBook);
                        }
                        else Console.WriteLine("You cant take more than 3 books!");

                        break;
                    case 3:
                        Console.WriteLine("You chose return book command!");
                        Console.Write("Book ISBN:");
                        _takenBookService.Return(Console.ReadLine());
                        break;
                    case 4:
                        Console.WriteLine("You chose display books command!");
                        Console.Write("Filter:");
                        var filter = Console.ReadLine();
                        Console.Write("Value:");
                        var value = Console.ReadLine();
                        _bookService.DisplayBooks(filter, value);
                        break;
                    case 5:
                        Console.WriteLine("You chose delete book command!");
                        Console.Write("Book ISBN:");
                        var ISBN = Console.ReadLine();
                        _bookService.DeleteBook(ISBN);
                        break;

                }

            }
        }
    }
}
