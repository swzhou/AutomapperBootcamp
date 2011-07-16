using Com.Swzhou.Automapper.Bootcamp;
using Com.Swzhou.Automapper.Bootcamp.Dtos;
using Com.Swzhou.Automapper.Bootcamp.Engines;
using Com.Swzhou.Automapper.Bootcamp.Models;
using Machine.Specifications;

namespace Test.Com.Swzhou.Automapper.Bootcamp.DtoToModel
{
    public class when_map_book_dto_to_author
    {
        private const string FirstAuthorName = "Swing Zhou";
        private const string FirstAuthorEmail = "swing.zhou@hotmail.com";
        private const string SecondAuthorName = "Matt Rogen";
        private const string SecondAuthorDescription = "Description of Matt Rogen";
        private const string SecondAuthorBlog = "matt.amazon.com";
        protected static BookDto Dto;
        protected static Author FirstAuthor;
        protected static Author SecondAuthor;

        Establish context = () =>
        {
            Dto = new BookDto
            {
                FirstAuthorName = FirstAuthorName,
                FirstAuthorEmail = FirstAuthorEmail,
                SecondAuthorName = SecondAuthorName,
                SecondAuthorBlog = SecondAuthorBlog,
                SecondAuthorDescription = SecondAuthorDescription,
            };
        };

        Because of = () =>
        {
            FirstAuthor = MyMapper.Map<BookDto, Author>(Dto, Engine.First);
            SecondAuthor = MyMapper.Map<BookDto, Author>(Dto, Engine.Second);
        };

        It should_succeed_to_set_member_values_for_first_author = () =>
        {
            FirstAuthor.Name.ShouldEqual(FirstAuthorName);
            FirstAuthor.ContactInfo.ShouldNotBeNull();
            FirstAuthor.ContactInfo.Email.ShouldEqual(FirstAuthorEmail);
        };

        It should_succeed_to_set_member_values_for_second_author = () =>
        {
            SecondAuthor.Name.ShouldEqual(SecondAuthorName);
            SecondAuthor.Description.ShouldEqual(SecondAuthorDescription);
            SecondAuthor.ContactInfo.ShouldNotBeNull();
            SecondAuthor.ContactInfo.Blog.ShouldEqual(SecondAuthorBlog);
        };
    }
}