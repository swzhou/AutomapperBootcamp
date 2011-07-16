using AutoMapper;

namespace Com.Swzhou.Automapper.Bootcamp.Mappings
{
    public abstract class DefaultMapping<TSource, TTarget> : IMapping
    {
        #region IMapping Members

        public void AddTo(Configuration config)
        {
            var map = config.CreateMap<TSource, TTarget>();
            MapMembers(map);
        }

        #endregion

        protected virtual void MapMembers(IMappingExpression<TSource, TTarget> map)
        {
        }
    }
}