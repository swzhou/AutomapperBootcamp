using Com.Swzhou.Automapper.Bootcamp;
using Com.Swzhou.Automapper.Bootcamp.Dtos;
using Com.Swzhou.Automapper.Bootcamp.Engines;
using Com.Swzhou.Automapper.Bootcamp.Models;
using Machine.Specifications;

namespace Test.Com.Swzhou.Automapper.Bootcamp.DtoToModel
{
    public class when_map_book_dto_to_contact_info
    {
        private const string FirstAuthorEmail = "swing.zhou@hotmail.com";
        private const string FirstAuthorBlog = "swing-zhou.iteye.com";
        private const string SecondAuthorBlog = "matt.amazon.com";
        private const string SecondAuthorTwitter = "@matt";
        protected static BookDto Dto;
        protected static ContactInfo ContactOfFirstAuthor;
        protected static ContactInfo ContactOfSecondAuthor;

        Establish context = () =>
        {
            Dto = new BookDto
                        {
                            FirstAuthorEmail = FirstAuthorEmail,
                            FirstAuthorBlog = FirstAuthorBlog,
                            SecondAuthorBlog = SecondAuthorBlog,
                            SecondAuthorTwitter = SecondAuthorTwitter,
                        };
        };

        Because of = () =>
        {
            ContactOfFirstAuthor = MyMapper.Map<BookDto, ContactInfo>(Dto, Engine.First);
            ContactOfSecondAuthor = MyMapper.Map<BookDto, ContactInfo>(Dto, Engine.Second);
        };

        It should_succeed_to_set_member_values_of_contact_of_first_author = () =>
        {
            ContactOfFirstAuthor.Email.ShouldEqual(FirstAuthorEmail);
            ContactOfFirstAuthor.Blog.ShouldEqual(FirstAuthorBlog);
            ContactOfFirstAuthor.Twitter.ShouldBeNull();
        };
        
        It should_succeed_to_set_member_values_of_contact_of_second_author = () =>
        {
            ContactOfSecondAuthor.Email.ShouldBeNull();
            ContactOfSecondAuthor.Blog.ShouldEqual(SecondAuthorBlog);
            ContactOfSecondAuthor.Twitter.ShouldEqual(SecondAuthorTwitter);
        };
    }
}