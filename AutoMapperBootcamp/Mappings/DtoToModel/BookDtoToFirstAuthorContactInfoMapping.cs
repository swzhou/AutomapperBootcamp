using AutoMapper;
using Com.Swzhou.Automapper.Bootcamp.Dtos;
using Com.Swzhou.Automapper.Bootcamp.Engines;
using Com.Swzhou.Automapper.Bootcamp.Models;

namespace Com.Swzhou.Automapper.Bootcamp.Mappings.DtoToModel
{
    [ApplyTo(Engine.First)]
    internal class BookDtoToFirstAuthorContactInfoMapping : DefaultMapping<BookDto, ContactInfo>
    {
        protected override void MapMembers(IMappingExpression<BookDto, ContactInfo> map)
        {
            map.ConstructUsing(s => new ContactInfo
                                          {
                                              Blog = s.FirstAuthorBlog,
                                              Email = s.FirstAuthorEmail,
                                              Twitter = s.FirstAuthorTwitter
                                          });
        }
    }
}