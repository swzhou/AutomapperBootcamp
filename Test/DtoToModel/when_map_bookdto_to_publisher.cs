using Com.Swzhou.Automapper.Bootcamp;
using Com.Swzhou.Automapper.Bootcamp.Dtos;
using Com.Swzhou.Automapper.Bootcamp.Models;
using Machine.Specifications;

namespace Test.Com.Swzhou.Automapper.Bootcamp.DtoToModel
{
    public class when_map_bookdto_to_publisher
    {
        private const string PublisherName = "TURING";
        protected static BookDto Dto;
        protected static Publisher Publisher;

        Establish context = () =>
                                {
                                    Dto = new BookDto
                                              {
                                                  Publisher = PublisherName
                                              };
                                };

        Because of = () => Publisher = MyMapper.Map<BookDto, Publisher>(Dto);

        It should_set_publisher_name_of_publisher_with_value_from_book_dto = () => Publisher.Name.ShouldEqual(PublisherName);
    }
}