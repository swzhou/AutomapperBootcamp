using System.Collections.Generic;

namespace Com.Swzhou.Automapper.Bootcamp.Dtos
{
    public class BookStoreDto
    {
        public string Name { get; set; }
        public List<BookDto> Books { get; set; }
        public AddressDto Address { get; set; }
    }
}