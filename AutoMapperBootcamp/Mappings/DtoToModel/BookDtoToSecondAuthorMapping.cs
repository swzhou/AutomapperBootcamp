using AutoMapper;
using Com.Swzhou.Automapper.Bootcamp.Dtos;
using Com.Swzhou.Automapper.Bootcamp.Engines;
using Com.Swzhou.Automapper.Bootcamp.Models;

namespace Com.Swzhou.Automapper.Bootcamp.Mappings.DtoToModel
{
    [ApplyTo(Engine.Second)]
    internal class BookDtoToSecondAuthorMapping : DefaultMapping<BookDto, Author>
    {
        protected override void MapMembers(IMappingExpression<BookDto, Author> map)
        {
            map.ForMember(d => d.Name, opt => opt.MapFrom(s => s.SecondAuthorName))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.SecondAuthorDescription))
                .ForMember(d => d.ContactInfo,
                           opt => opt.ResolveUsing<SecondAuthorContactInfoResolver>()
                                      .ConstructedBy(() => new SecondAuthorContactInfoResolver()));
        }

        #region Nested type: SecondAuthorContactInfoResolver

        private class SecondAuthorContactInfoResolver : DefaultValueResolver<BookDto,ContactInfo>
        {
            protected override bool TargetIsDefault(BookDto source)
            {
                return string.IsNullOrEmpty(source.SecondAuthorBlog)
                       && string.IsNullOrEmpty(source.SecondAuthorEmail)
                       && string.IsNullOrEmpty(source.SecondAuthorTwitter);
            }

            protected override ContactInfo DoResolve(BookDto source)
            {
                return MyMapper.Map<BookDto, ContactInfo>(source, Engine.Second);
            }
        }

        #endregion
    }
}