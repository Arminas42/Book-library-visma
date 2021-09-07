using Book_Library.Infrastructure;
using Book_Library.Models;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Library.Services
{
    public class JsonBookData : IBookData
    {
        private string _file = @"C:\Users\Arminas\source\repos\Book-Library\Books.json";
        public List<Book> Read()
        {
            var books = new List<Book>();
            if (!File.Exists(_file))
            {
                return books;
            }
            else
            {
                try
                {
                    using (StreamReader sr = new StreamReader(_file))
                    {
                        string json = sr.ReadToEnd();
                        books = JsonSerializer.Deserialize<List<Book>>(json);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }
                return books;
            }
            
        }

        public void Write(List<Book> books)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(_file))
                {
                    sw.WriteLine(JsonSerializer.Serialize(books));
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to write book to file! Error: {0}", ex.Message);
            }
        }
    }
}
