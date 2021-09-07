using Book_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Library.Infrastructure
{
    public interface IBookData
    {
        public List<Book> Read();
        public void Write(List<Book> books);
    }
}
