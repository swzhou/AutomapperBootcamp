using AutoMapper;

namespace Com.Swzhou.Automapper.Bootcamp.Mappings
{
    public interface IMapping
    {
        void AddTo(Configuration config);
    }

    public static class ConfigurationExtensions
    {
        public static void Add(this Configuration config, IMapping mapping)
        {
            mapping.AddTo(config);
        }
    }
}