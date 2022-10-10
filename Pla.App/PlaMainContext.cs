using System;
using Pla.Lib;
using SkiaSharp;

namespace Pla.App
{
    public class PlaMainContext : IPainter, IControl, IContext
    {
        IEngine _engine;

        public IControl GetControl()
        {
            return this;
        }

        public IPainter GetPainter()
        {
            return this;
        }

        public void Init(IEngine engine)
        {
            this._engine = engine;
        }

        public void KeyDown(uint key)
        {
        }

        public void Click(SKPoint argsLocation)
        {
        }

        public void Paint(SKImageInfo info, SKSurface surface)
        {
        }
    }
}