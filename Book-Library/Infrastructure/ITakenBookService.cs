using Book_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Library.Infrastructure
{
    public interface ITakenBookService
    {
        public void Create(TakenBook takenbook);
        public void Return(string ISBN);
        public bool CanTakeMoreBooks(string person);
    }
}
