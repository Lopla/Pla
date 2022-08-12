using System.Linq;
using SkiaSharp;

namespace Pla.Lib.UI
{
    enum Styling
    {
        Background = 0,
        Border1,
        Alert,
        Success,
        Disabled,
        Border2,
        Border3,
        Border4,
        Border5,
        Border6,
        Border7,
        Border8
    }

    /// <summary>
    ///     Warp 10
    /// </summary>
    public class LCars 
    {
        private readonly string[] colourMap =
        {
            "#000000", // background and text
            "#ff7700", // orange - normal border
            "#ff2200", // red
            "#33cc99", // green
            "#666688", // gray
            "#ffcc33",
            "#cc88ff",
            "#ddbbff",
            "#cc4499",
            "#4455ff",
            "#ffcc33",
            "#9944ff",
            "#ffaa90",
            "#ffcc66",
            "#7788ff"
        };

        private readonly SKColor[] _colours;

        public LCars()
        {
            _colours = colourMap.Select(SKColor.Parse).ToArray();
        }

        public void ModifyAble(PaintContext context)
        {
        }

        public void Text(PaintContext context, string text, SKTextAlign align, bool dark)
        {
            using (var painterBack = new SKPaint
                   {
                       TextAlign = align,
                       Color = dark ? _colours[(int)Styling.Background] : _colours[(int)Styling.Border1]
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
                       Color = _colours[(int)Styling.Border1],
                       Style = SKPaintStyle.Fill
                   })
            {
                context.canvas.DrawRoundRect(context.widgetSize, 10, 10, painterBorder);
            }
        }

        public void Visible(PaintContext context)
        {
            using (var painterBorder = new SKPaint
                   {
                       Color = _colours[(int)Styling.Border1],
                       Style = SKPaintStyle.Stroke
                   })
            using (var painterBack = new SKPaint
                   {
                       Color = _colours[(int)Styling.Background],
                       Style = SKPaintStyle.Fill
                   })
            {
                context.canvas.DrawRoundRect(context.widgetSize, 10, 10, painterBorder);
                context.canvas.DrawRoundRect(context.widgetSize, 10, 10, painterBack);
            }
        }

        public void ReadAble(PaintContext context)
        {
        }
    }
}