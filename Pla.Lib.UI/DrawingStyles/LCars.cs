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
        private readonly SKColor[] _colors;

        private readonly SKFont _font;
        private readonly SKPaint _fontDrawingPainter;

        private readonly string[] _colorMap =
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

        public LCars()
        {
            _colors = _colorMap.Select(SKColor.Parse).ToArray();
            _font = new SKFont(
                SKTypeface.Default,
                //SKTypeface.FromFamilyName("Arial Narrow",
                //    SKFontStyleWeight.Bold,
                //    SKFontStyleWidth.ExtraCondensed,
                //    SKFontStyleSlant.Upright),
                16
                );
            _fontDrawingPainter = new SKPaint(_font);

            TextLineHeight = -(int)_font.Metrics.Top ;
        }

        public int TextLineHeight = 0;
        public int BorderMargin = 10;

        public SKPoint CalculateTextSize(string text)
        {
            SKRect bounds = default;
            _fontDrawingPainter.MeasureText(text, ref bounds);

            return new SKPoint(bounds.Width, TextLineHeight);
        }

        /// <summary>
        ///     Edit boxes
        /// </summary>
        /// <param name="context"></param>
        public void ModifyAble(PaintContext context, string label = null, SKTextAlign align = SKTextAlign.Center)
        {
            using (var painterBorder = new SKPaint
                   {
                       Color = _colors[(int)Styling.Border1],
                       Style = SKPaintStyle.Fill
                   })
            {
                context.Canvas.DrawRoundRect(context.Bounds, BorderMargin, BorderMargin, painterBorder);
                ModifyAbleText(context, label, align);
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
                       Color = _colors[(int)Styling.Border1],
                       Style = SKPaintStyle.Fill
                   })
            {
                context.Canvas.DrawRoundRect(context.Bounds, BorderMargin, BorderMargin, painterBorder);
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
                       Color = _colors[(int)Styling.Border1],
                       Style = SKPaintStyle.Stroke
                   })
            using (var painterBack = new SKPaint
                   {
                       Color = _colors[(int)Styling.Background],
                       Style = SKPaintStyle.Fill
                   })
            {
                context.Canvas.DrawRoundRect(context.Bounds, BorderMargin, BorderMargin, painterBack);
                context.Canvas.DrawRoundRect(context.Bounds, BorderMargin, BorderMargin, painterBorder);
                Text(context, label, align, false);
            }
        }

        private void Text(PaintContext context, string text, SKTextAlign align, bool dark)
        {
            using (var painterBack = new SKPaint
                   {
                       TextAlign = align,
                       Color = dark ? _colors[(int)Styling.Background] : _colors[(int)Styling.Border1],
                       Typeface = _font.Typeface
                   })
            {
                var point = new SKPoint(context.Bounds.Left, context.Bounds.MidY);

                if (align == SKTextAlign.Center)
                {
                    point.X = context.Bounds.MidX;
                }
                else if (align == SKTextAlign.Right)
                {
                    point.X = context.Bounds.Right - BorderMargin;
                }else if (align == SKTextAlign.Left)
                {
                    point.X = context.Bounds.Left + BorderMargin;
                }

                point.Offset(0, this._font.Size / 2);

                if (text != null)
                    context.Canvas.DrawText(text, point, painterBack);
            }
        }

        public void ModifyAbleText(PaintContext ctx, string text, SKTextAlign align)
        {
            Text(ctx, text, align, true);
        }

        public void VisibleText(PaintContext paintContext, string text, SKTextAlign align)
        {
            Text(paintContext, text, align, false);
        }

        public void PointAbleText(PaintContext paintContext, string text, SKTextAlign align)
        {
            Text(paintContext, text, align, true);
        }
    }
}