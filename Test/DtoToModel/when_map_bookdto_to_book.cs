using System;
using Com.Swzhou.Automapper.Bootcamp;
using Com.Swzhou.Automapper.Bootcamp.Dtos;
using Com.Swzhou.Automapper.Bootcamp.Models;
using Machine.Specifications;
using System.Linq;

namespace Test.Com.Swzhou.Automapper.Bootcamp.DtoToModel
{
    public class when_map_bookdto_to_book
    {
        private const string FirstAuthorName = "Swing Zhou";
        private const string FirstAuthorEmail = "swing.zhou@hotmail.com";
        private const string SecondAuthorName = "Matt Rogen";
        private const string SecondAuthorDescription = "Description of Matt Rogen";
        private const string SecondAuthorBlog = "matt.amazon.com";
        private const string BookDescription = "Book desc";
        private const string BookTitle = "This Book";
        private const decimal BookPrice = 19.99M;
        private const string PublisherName = "O'REILLY";
        protected static BookDto Dto;
        protected static Book Book;

        Establish context = () =>
        {
            Dto = new BookDto
            {
                Title = BookTitle,
                Description = BookDescription,
                Price = BookPrice,
                PublishDate = PublishDate,
                FirstAuthorName = FirstAuthorName,
                FirstAuthorEmail = FirstAuthorEmail,
                SecondAuthorName = SecondAuthorName,
                SecondAuthorBlog = SecondAuthorBlog,
                SecondAuthorDescription = SecondAuthorDescription,
                Publisher = PublisherName,
            };
        };

        Because of = () => Book = MyMapper.Map<BookDto, Book>(Dto);

        It should_succeed_to_set_member_values_for_book = () =>
        {
            Book.Title.ShouldEqual(BookTitle);
            Book.Description.ShouldEqual(BookDescription);
            Book.Language.ShouldBeNull();
            Book.Paperback.ShouldBeNull();
            Book.Price.ShouldEqual(BookPrice);
            Book.PublishDate.ShouldEqual(PublishDate);
            Book.Publisher.ShouldNotBeNull();
            Book.Publisher.Name.ShouldEqual(PublisherName);
            Book.Authors.Count.ShouldEqual(2);
            var firstAuthor = Book.Authors.First();
            firstAuthor.Name.ShouldEqual(FirstAuthorName);
            firstAuthor.ContactInfo.ShouldNotBeNull();
            firstAuthor.ContactInfo.Email.ShouldEqual(FirstAuthorEmail);
            var secondAuthor = Book.Authors.Last();
            secondAuthor.Name.ShouldEqual(SecondAuthorName);
            secondAuthor.Description.ShouldEqual(SecondAuthorDescription);
            secondAuthor.ContactInfo.ShouldNotBeNull();
            secondAuthor.ContactInfo.Blog.ShouldEqual(SecondAuthorBlog);
        };

        private static readonly DateTime PublishDate = DateTime.Today;
    }
}