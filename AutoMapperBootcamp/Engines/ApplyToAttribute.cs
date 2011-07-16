using System;

namespace Com.Swzhou.Automapper.Bootcamp.Engines
{
    public class ApplyToAttribute : Attribute
    {
        private readonly Engine _engine;

        public ApplyToAttribute(Engine engine)
        {
            _engine = engine;
        }

        public Engine Engine
        {
            get { return _engine; }
        }
    }
}