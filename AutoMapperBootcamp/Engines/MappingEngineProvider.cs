using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using AutoMapper.Mappers;
using Com.Swzhou.Automapper.Bootcamp.Mappings;

namespace Com.Swzhou.Automapper.Bootcamp.Engines
{
    public class MappingEngineProvider
    {
        public static readonly MappingEngineProvider Basic = new MappingEngineProvider(Engine.Basic);
        public static readonly MappingEngineProvider First = new MappingEngineProvider(Engine.First);
        public static readonly MappingEngineProvider Second = new MappingEngineProvider(Engine.Second);

        private readonly MappingEngine _engine;

        public MappingEngineProvider(Engine engine)
        {
            var config = new Configuration(new TypeMapFactory(), MapperRegistry.AllMappers());
            GetMappingTypesTaggedWith(engine)
                .Select(type => (IMapping) Activator.CreateInstance(type))
                .ToList().ForEach(config.Add);
            _engine = new MappingEngine(config);
        }

        private static IEnumerable<Type> GetMappingTypesTaggedWith(Engine engine)
        {
            return Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => x.GetInterfaces().Contains(typeof (IMapping))
                            && Attribute.IsDefined(x, typeof (ApplyToAttribute))
                            && engine.ApplyTo(x)).ToList();
        }

        public MappingEngine Get()
        {
            return _engine;
        }
    }
}