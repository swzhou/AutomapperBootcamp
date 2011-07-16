using System.Collections.Generic;

namespace Com.Swzhou.Automapper.Bootcamp.Models
{
    public class BookStore
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
        public Address Address { get; set; }
    }
}