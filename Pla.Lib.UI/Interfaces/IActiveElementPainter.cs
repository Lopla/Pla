using System.Collections.Generic;
using SkiaSharp;

namespace Pla.Lib.UI.Interfaces
{
    public interface IActiveElementPainter
    {
        SKPoint GetTextTotalSize(IEnumerable<string> textLines);

        SKPoint CalculateTextSize(string text);

        void Draw(PaintContext paintContext, IEnumerable<string> textLines, SKColor color);
    }
}