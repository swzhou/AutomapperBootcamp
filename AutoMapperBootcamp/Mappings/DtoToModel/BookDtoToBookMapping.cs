using System.Collections.Generic;
using AutoMapper;
using Com.Swzhou.Automapper.Bootcamp.Dtos;
using Com.Swzhou.Automapper.Bootcamp.Engines;
using Com.Swzhou.Automapper.Bootcamp.Models;

namespace Com.Swzhou.Automapper.Bootcamp.Mappings.DtoToModel
{
    [ApplyTo(Engine.Basic)]
    public class BookDtoToBookMapping : DefaultMapping<BookDto, Book>
    {
        protected override void MapMembers(IMappingExpression<BookDto, Book> map)
        {
            map
                //                .ForMember(d => d.Publisher,
                //                           opt => opt.ResolveUsing<PublisherValueResolver>()
                //                                      .ConstructedBy(() => new PublisherValueResolver()))
                .ForMember(d => d.Authors,
                           opt => opt.ResolveUsing<AuthorsValueResolver>()
                                      .ConstructedBy(() => new AuthorsValueResolver()));
        }

        #region Nested type: AuthorsValueResolver

        private class AuthorsValueResolver : ValueResolver<BookDto, List<Author>>
        {
            protected override List<Author> ResolveCore(BookDto source)
            {
                var firstAuthor = MyMapper.Map<BookDto, Author>(source, Engine.First);
                var secondAuthor = MyMapper.Map<BookDto, Author>(source, Engine.Second);
                return firstAuthor.IsNull()
                           ? secondAuthor.IsNull() ? new List<Author>() : new List<Author> {new Author(), secondAuthor}
                           : secondAuthor.IsNull()
                                 ? new List<Author> {firstAuthor}
                                 : new List<Author> {firstAuthor, secondAuthor};
            }
        }

        #endregion

        #region Nested type: PublisherValueResolver

        private class PublisherValueResolver : DefaultValueResolver<BookDto, Publisher>
        {
            protected override bool TargetIsDefault(BookDto source)
            {
                return string.IsNullOrEmpty(source.Publisher);
            }

            protected override Publisher DoResolve(BookDto source)
            {
                return MyMapper.Map<BookDto, Publisher>(source);
            }
        }

        #endregion
    }
}