using AutoMapper;
using Com.Swzhou.Automapper.Bootcamp.Dtos;
using Com.Swzhou.Automapper.Bootcamp.Engines;
using Com.Swzhou.Automapper.Bootcamp.Models;

namespace Com.Swzhou.Automapper.Bootcamp.Mappings.DtoToModel
{
    [ApplyTo(Engine.First)]
    internal class BookDtoToFirstAuthorMapping : DefaultMapping<BookDto, Author>
    {
        protected override void MapMembers(IMappingExpression<BookDto, Author> map)
        {
            map.ForMember(d => d.Name, opt => opt.MapFrom(s => s.FirstAuthorName))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.FirstAuthorDescription))
                .ForMember(d => d.ContactInfo,
                           opt => opt.ResolveUsing<FirstAuthorContactInfoResolver>()
                                      .ConstructedBy(() => new FirstAuthorContactInfoResolver()));
        }

        #region Nested type: FirstAuthorContactInfoResolver

        private class FirstAuthorContactInfoResolver : DefaultValueResolver<BookDto, ContactInfo>
        {
            protected override bool TargetIsDefault(BookDto source)
            {
                return string.IsNullOrEmpty(source.FirstAuthorBlog)
                       && string.IsNullOrEmpty(source.FirstAuthorEmail)
                       && string.IsNullOrEmpty(source.FirstAuthorTwitter);
            }

            protected override ContactInfo DoResolve(BookDto source)
            {
                return MyMapper.Map<BookDto, ContactInfo>(source, Engine.First);
            }
        }

        #endregion
    }
}