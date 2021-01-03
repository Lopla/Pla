using System;
using Pla.Lib;
using SkiaSharp;

namespace Pla.App
{
    public class PlaMainContext : IPainter, IControl, IContext
    {
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
        }

        public void KeyDown(uint key)
        {
        }

        public void Click(SKPoint argsLocation)
        {
        }

        public void Paint(SKImageInfo info, SKSurface surface)
        {
             using(var painter = new SKPaint(){
                Color = new SKColor(255,255,255)
            })
            {
                surface.Canvas.DrawText("Hello PLA", 10,10, painter);
            }
        }
    }
}