using System.Linq;
using Pla.Lib.UI.Interfaces;
using SkiaSharp;

namespace Pla.Lib.UI.DrawingStyles
{
    /// <summary>
    ///     Warp 10
    /// </summary>
    public class LCars : IDesign
    {
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

        private readonly SKColor[] _colors;

        private readonly SKFont _font;
        private readonly SKPaint _fontDrawingPainter;
        private readonly SKPaint _fontDrawingPainterWhite;
        public int Ascender;
        public int BorderMargin = 10;
        public int Descender;
        public int TextLineHeight;

        public LCars()
        {
            _colors = _colorMap.Select(SKColor.Parse).ToArray();
            _font = new SKFont(
                SKTypeface.Default
                //SKTypeface.FromFamilyName("Arial Narrow",
                //    SKFontStyleWeight.Bold,
                //    SKFontStyleWidth.ExtraCondensed,
                //    SKFontStyleSlant.Upright)
            );

            int TextSize = 18;

            _fontDrawingPainter = new SKPaint
            {
                Color = _colors[(int)Styling.Background],
                Typeface = _font.Typeface,
                TextSize = TextSize
            };
            _fontDrawingPainterWhite = new SKPaint
            {
                Color = _colors[(int)Styling.Border1],
                Typeface = _font.Typeface,
                TextSize = TextSize
            };

            Ascender = -(int)_font.Metrics.Ascent;
            Descender = (int)_font.Metrics.Descent;
            TextLineHeight = Ascender + Descender;
        }


        public SKPoint CalculateTextSize(string text)
        {
            SKRect bounds = default;
            _fontDrawingPainter.MeasureText(text, ref bounds);

            return new SKPoint(bounds.Width, this.GetTextHeight());
        }

        public int GetTextHeight()
        {
            return (int)_fontDrawingPainter.TextSize;
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
            using (var background = new SKPaint
                   {
                       Color = _colors[(int)Styling.Background],
                       Style = SKPaintStyle.Fill
                   })
            {
                context.Canvas.DrawRoundRect(context.Bounds, BorderMargin, BorderMargin, painterBorder);
                var b = context.Bounds;
                b.Left += BorderMargin / 2;
                b.Top += 2;
                b.Bottom -= 2;
                context.Canvas.DrawRoundRect(b, BorderMargin, BorderMargin, background);
                var c = b;
                c.Left = context.Bounds.Right - BorderMargin;

                context.Canvas.DrawRect(c, background);
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

        public void ModifyAbleText(PaintContext ctx, string text, SKTextAlign align)
        {
            Text(ctx, text, align, false);
        }

        public void VisibleText(PaintContext paintContext, string text, SKTextAlign align)
        {
            Text(paintContext, text, align, false);
        }

        public void PointAbleText(PaintContext paintContext, string text, SKTextAlign align)
        {
            Text(paintContext, text, align, true);
        }

        private void Text(PaintContext context, string text, SKTextAlign align, bool dark)
        {
            var point = new SKPoint(context.Bounds.Left, context.Bounds.MidY);

            if (align == SKTextAlign.Center)
                point.X = context.Bounds.MidX;
            else if (align == SKTextAlign.Right)
                point.X = context.Bounds.Right - BorderMargin;
            else if (align == SKTextAlign.Left)
                point.X = context.Bounds.Left + BorderMargin;

            point.Offset(0, -_fontDrawingPainter.FontMetrics.Ascent / 2);

            if (text != null)
                context.Canvas.DrawText(text, point, dark ? _fontDrawingPainter : _fontDrawingPainterWhite);
        }
    }
}