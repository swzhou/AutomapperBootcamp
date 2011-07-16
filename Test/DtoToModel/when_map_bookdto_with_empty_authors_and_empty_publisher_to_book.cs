using Com.Swzhou.Automapper.Bootcamp;
using Com.Swzhou.Automapper.Bootcamp.Dtos;
using Com.Swzhou.Automapper.Bootcamp.Models;
using Machine.Specifications;

namespace Test.Com.Swzhou.Automapper.Bootcamp.DtoToModel
{
    public class when_map_bookdto_with_empty_authors_and_empty_publisher_to_book
    {
        protected static BookDto Dto;
        protected static Book Book;

        Establish context = () => Dto = new BookDto();

        Because of = () => Book = MyMapper.Map<BookDto, Book>(Dto);

        It should_get_book_with_empty_authors_and_empty_publisher = () =>
        {
            Book.ShouldNotBeNull();
            Book.Publisher.ShouldBeNull();
            Book.Authors.ShouldNotBeNull();
            Book.Authors.Count.ShouldEqual(0);
        };
    }
}