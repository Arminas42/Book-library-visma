using Book_Library.Infrastructure;
using Book_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Library.Services
{
    public class BookService : IBookService
    {
        private IBookData _bookData;
        private ITakenBookData _takenBookData;
        public BookService(IBookData bookData, ITakenBookData takenBookData)
        {
            _bookData = bookData;
            _takenBookData = takenBookData;
        }
        public void AddBook(Book book)
        {
            var books = _bookData.Read();
            books.Add(book);
            _bookData.Write(books);
        }

        public void DeleteBook(string ISBN)
        {
            var books = _bookData.Read();
            var itemToRemove = books.Single(x => x.ISBN == ISBN);
            books.Remove(itemToRemove);
            _bookData.Write(books);
        }

        public void DisplayBooks(string filter, string value)
        {
            var books = _bookData.Read();
            var takenBooks = _takenBookData.Read();
            var filteredBooks = new List<Book>();
            if(filter == "author")
            {
                ConsoleDisplayBooks(books.Where(x => x.Author == value).ToList());
                
            }
            if (filter == "category")
            {
                ConsoleDisplayBooks(books.Where(x => x.Category == value).ToList());
            }
            if (filter == "language")
            {
                ConsoleDisplayBooks(books.Where(x => x.Language == value).ToList());
            }
            if (filter == "isbn")
            {
                ConsoleDisplayBooks(books.Where(x => x.ISBN == value).ToList());
            }
            if (filter == "name")
            {
                ConsoleDisplayBooks(books.Where(x => x.Name == value).ToList());
            }
            if (filter == "all")
            {
                ConsoleDisplayBooks(books);
            };
            if (filter == "available")
            {
                foreach(var takenBook in takenBooks)
                {
                    var bookToRemove = books.Where(x => x.ISBN == takenBook.bookISBN).FirstOrDefault();
                    if (bookToRemove != null)
                    {
                        books.Remove(bookToRemove);

                    }
                }
                ConsoleDisplayBooks(books);
            };
            if (filter == "taken")
            {
                var takenBookList = new List<Book>();
                foreach (var takenBook in takenBooks)
                {
                    var bookToAdd = books.Where(x => x.ISBN == takenBook.bookISBN).FirstOrDefault();
                    if (bookToAdd != null)
                    {
                        takenBookList.Add(bookToAdd);

                    }
                }
                ConsoleDisplayBooks(takenBookList);
            };
        }
        private void ConsoleDisplayBooks(List<Book> books)
        {
            Console.WriteLine();
            Console.WriteLine("**Name**Author**ISBN**Category**Language**Publication Date**");
            foreach (var book in books)
            {
                Console.WriteLine("**{0}**{1}**{2}**{3}**{4}**{5}**", book.Name, book.Author, book.ISBN, book.Category, book.Language, book.PublicationDate);

            }
            Console.WriteLine();

        }
    }
}
