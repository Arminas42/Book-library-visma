using Book_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Library.Infrastructure
{
    public interface IBookService
    {
        public void AddBook(Book book);
        public void DeleteBook(string ISBN);
        public void DisplayBooks(string filter, string value);

    }
}
