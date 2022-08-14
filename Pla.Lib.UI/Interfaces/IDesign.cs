using System.Collections.Generic;
using SkiaSharp;

namespace Pla.Lib.UI.Interfaces
{
    public interface IDesign
    {
        SKPoint CalculateTextSize(string text);
        SKPoint GetTextTotalSize(IEnumerable<string> lines);

        /// <summary>
        ///     Edit boxes
        /// </summary>
        /// <param name="context"></param>
        void ModifyAble(PaintContext context, string label = null, SKTextAlign align = SKTextAlign.Center);

        /// <summary>
        ///     Clickable touchable elements like buttons, radio etc.
        /// </summary>
        /// <param name="context"></param>
        void PointAble(PaintContext context, string label = null, SKTextAlign align = SKTextAlign.Center);

        /// <summary>
        ///     Passive ui element like frames and labels
        /// </summary>
        /// <param name="context"></param>
        void Visible(PaintContext context, string label = null, SKTextAlign align = SKTextAlign.Center);

        void ModifyAbleText(PaintContext ctx, string text, SKTextAlign align);
        void VisibleText(PaintContext paintContext, string text, SKTextAlign align);
        void PointAbleText(PaintContext paintContext, string text, SKTextAlign align);
        int GetTextHeight();
        int GetDescender();
        void DrawAllText(PaintContext paintContext, string[] textLines);
    }
}