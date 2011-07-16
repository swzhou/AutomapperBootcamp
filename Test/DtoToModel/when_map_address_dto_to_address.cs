using Com.Swzhou.Automapper.Bootcamp;
using Com.Swzhou.Automapper.Bootcamp.Dtos;
using Com.Swzhou.Automapper.Bootcamp.Models;
using Machine.Specifications;

namespace Test.Com.Swzhou.Automapper.Bootcamp.DtoToModel
{
    public class when_map_address_dto_to_address
    {
        private const string Country = "China";
        private const string City = "Beijing";
        private const string Street = "Dongzhimen Street";
        private const string PostCode = "100001";
        protected static Address Address;
        protected static AddressDto Dto;

        Establish context = () => Dto = new AddressDto
                                                    {
                                                        Country = Country,
                                                        City = City,
                                                        Street = Street,
                                                        PostCode = PostCode
                                                    };

        Because of = () => Address = MyMapper.Map<AddressDto, Address>(Dto);

        It should_succeed = () =>
        {
            Address.Country.ShouldEqual(Country);
            Address.City.ShouldEqual(City);
            Address.Street.ShouldEqual(Street);
            Address.PostCode.ShouldEqual(PostCode);
        };
    }
}