using System.Collections.Generic;
using Com.Swzhou.Automapper.Bootcamp;
using Com.Swzhou.Automapper.Bootcamp.Dtos;
using Com.Swzhou.Automapper.Bootcamp.Models;
using Machine.Specifications;
using System.Linq;

namespace Test.Com.Swzhou.Automapper.Bootcamp.DtoToModel
{
    public class when_map_book_store_dto_to_bookstore
    {
        protected static BookStoreDto Dto;
        protected static BookStore BookStore;

        Establish context = () => Dto = new BookStoreDto
                                                          {
                                                              Name = "My Store",
                                                              Address = new AddressDto
                                                                            {
                                                                                City = "Beijing"
                                                                            },
                                                              Books = new List<BookDto>
                                                                          {
                                                                              new BookDto {Title = "RESTful Web Service"},
                                                                              new BookDto {Title = "Ruby for Rails"},
                                                                          }
                                                          };

        Because of = () => BookStore = MyMapper.Map<BookStoreDto, BookStore>(Dto);

        It should_succeed = () =>
        {
            BookStore.Name.ShouldEqual("My Store");
            BookStore.Address.City.ShouldEqual("Beijing");
            BookStore.Books.Count.ShouldEqual(2);
            BookStore.Books.First().Title.ShouldEqual("RESTful Web Service");
            BookStore.Books.Last().Title.ShouldEqual("Ruby for Rails");
        };
    }
}