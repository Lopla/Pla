using System;
using SkiaSharp;

namespace Pla.Lib
{
    public interface IPainter
    {
        void Paint(SKImageInfo info, SKSurface surface);
    }
}
