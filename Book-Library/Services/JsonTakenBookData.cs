using Book_Library.Infrastructure;
using Book_Library.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Book_Library.Services
{
    class JsonTakenBookData : ITakenBookData
    {
        private string _file = @"C:\Users\Arminas\source\repos\Book-Library\TakenBooks.json";
        public List<TakenBook> Read()
        {
            var takenBooks = new List<TakenBook>();
            if (!File.Exists(_file))
            {
                return takenBooks;
            }
            else
            {
                try
                {
                    using (StreamReader sr = new StreamReader(_file))
                    {
                        string json = sr.ReadToEnd();
                        takenBooks = JsonSerializer.Deserialize<List<TakenBook>>(json);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }
                return takenBooks;
            }

        }

        public void Write(List<TakenBook> takenBooks)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(_file))
                {
                    sw.WriteLine(JsonSerializer.Serialize(takenBooks));

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to write book to file! Error: {0}", ex.Message);
            }
        }
    }
}
