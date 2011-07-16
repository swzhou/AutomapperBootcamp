using AutoMapper;
using Com.Swzhou.Automapper.Bootcamp.Dtos;
using Com.Swzhou.Automapper.Bootcamp.Engines;
using Com.Swzhou.Automapper.Bootcamp.Models;

namespace Com.Swzhou.Automapper.Bootcamp.Mappings.DtoToModel
{
    [ApplyTo(Engine.Second)]
    internal class BookDtoToSecondAuthorContactInfoMapping : DefaultMapping<BookDto, ContactInfo>
    {
        protected override void MapMembers(IMappingExpression<BookDto, ContactInfo> map)
        {
            map.ForMember(d => d.Email, opt => opt.MapFrom(s => s.SecondAuthorEmail))
                .ForMember(d => d.Blog, opt => opt.MapFrom(s => s.SecondAuthorBlog))
                .ForMember(d => d.Twitter, opt => opt.MapFrom(s => s.SecondAuthorTwitter));
        }
    }
}