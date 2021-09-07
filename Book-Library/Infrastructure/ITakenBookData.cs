using Book_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Library.Infrastructure
{
    public interface ITakenBookData
    {
        public List<TakenBook> Read();
        public void Write(List<TakenBook> takenBooks);
    }
}
