using Pla.Lib.UI.Interfaces;
using SkiaSharp;

namespace Pla.Lib.UI.DrawingStyles
{
    public class LCarsOrnaments : IOrnamentsPainter
    {
        public LCarsPalette palette = new LCarsPalette();

        public void Draw(PaintContext context)
        {
            using (var painterBorder = new SKPaint
                   {
                       Color = palette.Colour(Styling.Border7),
                       Style = SKPaintStyle.Stroke
                   })
            {
                context.Canvas.DrawRect(context.Bounds, painterBorder);

                ///ModifyAbleText(context, label, align);
            }
        }
    }
}