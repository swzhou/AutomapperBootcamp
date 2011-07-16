using System;
using System.Linq;

namespace Com.Swzhou.Automapper.Bootcamp.Engines
{
    public enum Engine
    {
        Basic = 0,
        First,
        Second
    }

    public static class EngineExtensions
    {
        public static bool ApplyTo(this Engine engine, Type type)
        {
            var attributes = (ApplyToAttribute[])type.GetCustomAttributes(typeof(ApplyToAttribute), false);
            return attributes.Any(attr => attr.Engine == engine);
        }
    }
}