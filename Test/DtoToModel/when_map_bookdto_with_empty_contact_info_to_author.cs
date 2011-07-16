using Com.Swzhou.Automapper.Bootcamp;
using Com.Swzhou.Automapper.Bootcamp.Dtos;
using Com.Swzhou.Automapper.Bootcamp.Engines;
using Com.Swzhou.Automapper.Bootcamp.Models;
using Machine.Specifications;

namespace Test.Com.Swzhou.Automapper.Bootcamp.DtoToModel
{
    public class when_map_bookdto_with_empty_contact_info_to_author
    {
        protected static BookDto Dto;
        protected static Author FirstAuthor;
        protected static Author SecondAuthor;

        Establish context = () => Dto = new BookDto();

        Because of = () =>
        {
            FirstAuthor = MyMapper.Map<BookDto, Author>(Dto, Engine.First);
            SecondAuthor = MyMapper.Map<BookDto, Author>(Dto, Engine.Second);
        };

        It should_get_first_author_with_null_contact_info = () =>
        {
            FirstAuthor.ShouldNotBeNull();
            FirstAuthor.ContactInfo.ShouldBeNull();
        };

        It should_get_second_author_with_null_contact_info = () =>
        {
            SecondAuthor.ShouldNotBeNull();
            SecondAuthor.ContactInfo.ShouldBeNull();
        };
    }
}