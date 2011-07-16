using System.Linq;
using Com.Swzhou.Automapper.Bootcamp;
using Com.Swzhou.Automapper.Bootcamp.Dtos;
using Com.Swzhou.Automapper.Bootcamp.Models;
using Machine.Specifications;

namespace Test.Com.Swzhou.Automapper.Bootcamp.DtoToModel
{
    public class when_map_bookdto_with_null_first_author_and_non_null_second_author_to_book
    {
        protected static BookDto Dto;
        protected static Book Book;

        Establish context = () => Dto = new BookDto()
                                            {
                                                SecondAuthorName = "Sam Ruby",
                                            };

        Because of = () => Book = MyMapper.Map<BookDto, Book>(Dto);

        It should_get_book_with_empty_first_author_and_non_empty_second_author = () =>
        {
            Book.Authors.Count.ShouldEqual(2);
            Book.Authors.First().IsNull().ShouldBeTrue();
            Book.Authors.Last().IsNull().ShouldBeFalse();
        };
    }
}