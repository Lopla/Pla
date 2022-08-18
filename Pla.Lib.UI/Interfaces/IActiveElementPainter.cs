using System.Collections.Generic;
using SkiaSharp;

namespace Pla.Lib.UI.Interfaces
{
    public interface IActiveElementPainter
    {
        SKPoint GetSize();
        
        void Draw(PaintContext paintContext);
    }
}