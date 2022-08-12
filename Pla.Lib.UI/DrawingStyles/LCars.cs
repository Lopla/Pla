using System.Linq;
using SkiaSharp;

namespace Pla.Lib.UI.DrawingStyles
{
    /// <summary>
    ///     Warp 10
    /// </summary>
    public class LCars : IDrawingStyle
    {
        private readonly string[] colourMap =
        {
            "#000000", // background and text
            "#ff7700", // orange - normal border
            "#ff2200", // red
            "#33cc99", // green
            "#666688", // gray
            "#ffcc33",
            "#cc88ff"
        };

        private readonly SKColor[] colours;

        public LCars()
        {
            colours = colourMap.Select(SKColor.Parse).ToArray();
        }

        public void ModifyAble(PaintContext context)
        {
        }

        public void Text(PaintContext context, string text, SKTextAlign align)
        {
            using (var painterBack = new SKPaint
                   {
                       TextAlign = align,
                       Color = colours[(int)Styling.BackgroundAndText]
                   })
            {
                var point = new SKPoint(context.widgetSize.Left, context.widgetSize.MidY);
                if (align == SKTextAlign.Center)
                    point.X = context.widgetSize.MidX;
                else if (align == SKTextAlign.Right) point.X = context.widgetSize.Right;
                context.canvas.DrawText(text, point, painterBack);
            }
        }

        public void PointAble(PaintContext context)
        {
            using (var painterBorder = new SKPaint
                   {
                       Color = colours[(int)Styling.Border1],
                       Style = SKPaintStyle.Fill
                   })
            {
                context.canvas.DrawRect(context.widgetSize, painterBorder);
            }
        }

        public void ReadAble(PaintContext context)
        {
        }

        private enum Styling
        {
            BackgroundAndText = 0,
            Border1,
            Alert,
            Success,
            Disabled,
            Border2
        }
    }
}