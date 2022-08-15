using System.Collections.Generic;
using SkiaSharp;

namespace Pla.Lib.UI.Interfaces
{
    public interface IActiveElementPainter
    {
        SKPoint GetTextTotalSize(IEnumerable<string> textLines);
        
        void Draw(PaintContext paintContext, IEnumerable<string> textLines, Ornament ornamentType);
    }
}