using System.Collections.Generic;
using AutoMapper;
using Com.Swzhou.Automapper.Bootcamp.Engines;

namespace Com.Swzhou.Automapper.Bootcamp
{
    public class MyMapper
    {
        private static readonly Dictionary<Engine, MappingEngine> Engines = new Dictionary<Engine, MappingEngine>
                                                                       {
                                                                           {Engine.Basic, MappingEngineProvider.Basic.Get()},
                                                                           {Engine.First, MappingEngineProvider.First.Get()},
                                                                           {Engine.Second, MappingEngineProvider.Second.Get()},
                                                                       };

        public static TTarget Map<TSource, TTarget>(TSource source, Engine engine = Engine.Basic)
        {
            return Engines[engine].Map<TSource, TTarget>(source);
        }
    }
}