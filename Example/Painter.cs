using System;
using Pla.Lib;
using SkiaSharp;

namespace Example
{
    public class Painter : IPainter
    {
        public void Paint(SKCanvas canvas)
        {
            canvas.Clear(new SKColor(128,128,128));
            canvas.DrawRect(10,40,100,100,new SKPaint(){
                Color = new SKColor(1,1,1)
            });
            canvas.DrawText("Test", 10,10 , new SKPaint(){
                Color = new SKColor(255,255,255)
            });
            canvas.Flush();
        }
    }
}
