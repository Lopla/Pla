using System;
using Pla.Lib;

namespace Example
{
    public class Painter : IPainter
    {
        void Paint(SKCanvas canvas){
            
            canvas.Clear(new SkColor(128,128,128));
            canvas.Flush();
        }
    }
}
