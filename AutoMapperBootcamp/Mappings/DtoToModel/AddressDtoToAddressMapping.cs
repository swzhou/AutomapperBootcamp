using Com.Swzhou.Automapper.Bootcamp.Dtos;
using Com.Swzhou.Automapper.Bootcamp.Engines;
using Com.Swzhou.Automapper.Bootcamp.Models;

namespace Com.Swzhou.Automapper.Bootcamp.Mappings.DtoToModel
{

    [ApplyTo(Engine.Basic)]
    public class AddressDtoToAddressMapping : DefaultMapping<AddressDto,Address>
    {
    }
}