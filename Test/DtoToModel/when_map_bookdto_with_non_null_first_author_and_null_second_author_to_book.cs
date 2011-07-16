using System.Linq;
using Com.Swzhou.Automapper.Bootcamp;
using Com.Swzhou.Automapper.Bootcamp.Dtos;
using Com.Swzhou.Automapper.Bootcamp.Models;
using Machine.Specifications;

namespace Test.Com.Swzhou.Automapper.Bootcamp.DtoToModel
{
    public class when_map_bookdto_with_non_null_first_author_and_null_second_author_to_book
    {
        protected static BookDto Dto;
        protected static Book Book;

        Establish context = () => Dto = new BookDto
                                            {
                                                FirstAuthorName = "Sam Ruby",
                                            };

        Because of = () => Book = MyMapper.Map<BookDto, Book>(Dto);

        It should_get_book_with_non_empty_first_author_only = () =>
        {
            Book.Authors.Count.ShouldEqual(1);
            Book.Authors.First().IsNull().ShouldBeFalse();
            Book.Authors.First().ContactInfo.ShouldBeNull();
        };
    }
}