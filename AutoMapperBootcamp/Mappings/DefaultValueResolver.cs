using AutoMapper;

namespace Com.Swzhou.Automapper.Bootcamp.Mappings
{
    internal abstract class DefaultValueResolver<TSource, TTarget> : ValueResolver<TSource, TTarget>
    {
        protected override TTarget ResolveCore(TSource source)
        {
            return TargetIsDefault(source) ? default(TTarget) : DoResolve(source);
        }

        protected abstract bool TargetIsDefault(TSource source);
        protected abstract TTarget DoResolve(TSource source);
    }
}