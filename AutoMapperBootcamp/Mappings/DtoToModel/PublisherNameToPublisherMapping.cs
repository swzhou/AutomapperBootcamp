using AutoMapper;
using Com.Swzhou.Automapper.Bootcamp.Engines;
using Com.Swzhou.Automapper.Bootcamp.Models;

namespace Com.Swzhou.Automapper.Bootcamp.Mappings.DtoToModel
{
    [ApplyTo(Engine.Basic)]
    public class PublisherNameToPublisherMapping : DefaultMapping<string, Publisher>
    {
        protected override void MapMembers(IMappingExpression<string, Publisher> map)
        {
            map.ConvertUsing(new PublisherNameToPublisherConverter());
        }

        #region Nested type: PublisherNameToPublisherConverter

        private class PublisherNameToPublisherConverter : TypeConverter<string, Publisher>
        {
            protected override Publisher ConvertCore(string source)
            {
                return source == null ? null : new Publisher {Name = source};
            }
        }

        #endregion
    }
}