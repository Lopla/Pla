using System.Linq;
using SkiaSharp;

namespace Pla.Lib.UI.DrawingStyles
{
    internal enum Styling
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
        private readonly SKColor[] _colours;

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

        private readonly SKFont _font;
        private readonly SKPaint _fontDrawingPainter;

        public LCars()
        {
            _colours = colourMap.Select(SKColor.Parse).ToArray();
            this._font = new SKFont(SKTypeface.FromFamilyName("Arial Narrow", 
                SKFontStyleWeight.Bold, 
                SKFontStyleWidth.ExtraCondensed, 
                SKFontStyleSlant.Upright));
            this._fontDrawingPainter = new SKPaint(this._font);
        }

        public SKPoint SizeWithText(string text)
        {
            SKRect bounds = default;
            _fontDrawingPainter.MeasureText(text, ref bounds);
            return new SKPoint(bounds.Width, bounds.Height);
        }

        /// <summary>
        ///     Edit boxes
        /// </summary>
        /// <param name="context"></param>
        public void ModifyAble(PaintContext context, string label = null, SKTextAlign align = SKTextAlign.Center)
        {
            using (var painterBorder = new SKPaint
                   {
                       Color = _colours[(int)Styling.Border1],
                       Style = SKPaintStyle.Fill
                   })
            {
                context.Canvas.DrawRoundRect(context.Widget.Bounds, 10, 10, painterBorder);
                Text(context, label, align, true);
            }
        }

        /// <summary>
        ///     Clickable touchable elements like buttons, radio etc.
        /// </summary>
        /// <param name="context"></param>
        public void PointAble(PaintContext context, string label = null, SKTextAlign align = SKTextAlign.Center)
        {
            using (var painterBorder = new SKPaint
                   {
                       Color = _colours[(int)Styling.Border1],
                       Style = SKPaintStyle.Fill
                   })
            {
                context.Canvas.DrawRoundRect(context.Widget.Bounds, 10, 10, painterBorder);
                Text(context, label, align, true);
            }
        }

        /// <summary>
        ///     Passive ui element like frames and labels
        /// </summary>
        /// <param name="context"></param>
        public void Visible(PaintContext context, string label = null, SKTextAlign align = SKTextAlign.Center)
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
                context.Canvas.DrawRoundRect(context.Widget.Bounds, 10, 10, painterBack);
                context.Canvas.DrawRoundRect(context.Widget.Bounds, 10, 10, painterBorder);
                Text(context, label, align, false);
            }
        }

        private void Text(PaintContext context, string text, SKTextAlign align, bool dark)
        {
            using (var painterBack = new SKPaint
                   {
                       TextAlign = align,
                       Color = dark ? _colours[(int)Styling.Background] : _colours[(int)Styling.Border1],
                       Typeface = this._font.Typeface,
                   })
            {
                var textSize = SizeWithText(text);

                var point = new SKPoint(context.Widget.Bounds.Left, context.Widget.Bounds.MidY);
                if (align == SKTextAlign.Center)
                    point.X = context.Widget.Bounds.MidX;
                else if (align == SKTextAlign.Right) point.X = context.Widget.Bounds.Right;

                point.Offset(0, textSize.Y / 2);

                if(text!=null)
                    context.Canvas.DrawText(text, point, painterBack);
            }
        }

       
    }
}