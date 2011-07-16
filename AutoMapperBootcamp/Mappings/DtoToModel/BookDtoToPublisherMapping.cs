using AutoMapper;
using Com.Swzhou.Automapper.Bootcamp.Dtos;
using Com.Swzhou.Automapper.Bootcamp.Engines;
using Com.Swzhou.Automapper.Bootcamp.Models;

namespace Com.Swzhou.Automapper.Bootcamp.Mappings.DtoToModel
{
    [ApplyTo(Engine.Basic)]
    public class BookDtoToPublisherMapping : DefaultMapping<BookDto, Publisher>
    {
        protected override void MapMembers(IMappingExpression<BookDto, Publisher> map)
        {
            map.ForMember(d => d.Name, opt => opt.MapFrom(s => s.Publisher));
        }
    }
}