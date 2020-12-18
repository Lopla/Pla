using System;
using Pla.Lib;
using SkiaSharp;

namespace Example
{
    public class Ctx : IPainter, IControl, IContext
    {
        #region Instrumentation
        private IEngine engine;

        public IControl GetControl()
        {
            return this;
        }

        public IPainter GetPainter()
        {
            return this;
        }

        public void Init(IEngine engine)
        {
            this.engine = engine;
        }
        #endregion

        string text = "Hi";

        public void Paint(SKImageInfo info, SKSurface surface)
        {
            var canvas = surface.Canvas;

            canvas.Clear(new SKColor(184, 3, 255));

            canvas.DrawText(text, 10, 10, new SKPaint()
            {
                Color = new SKColor(255, 255, 255),
                Typeface = SKTypeface.FromFamilyName("DejaVu")
            });

            canvas.Flush();
        }

        private static void DrawBlackRect(SKCanvas canvas)
        {
            canvas.DrawRect(10, 40, 100, 100, new SKPaint()
            {
                Color = new SKColor(1, 1, 1)
            });
        }

        private static void DrawColorfullRect(SKImageInfo info, SKCanvas canvas)
        {
            using (SKPaint paint = new SKPaint())
            {
                // Create 300-pixel square centered rectangle
                float x = (info.Width - 300) / 2;
                float y = (info.Height - 300) / 2;
                SKRect rect = new SKRect(x, y, x + 300, y + 300);

                // Create linear gradient from upper-left to lower-right
                paint.Shader = SKShader.CreateLinearGradient(
                                    new SKPoint(rect.Left, rect.Top),
                                    new SKPoint(rect.Right, rect.Bottom),
                                    new SKColor[] { SKColors.Red, SKColors.Blue },
                                    new float[] { 0, 1 },
                                    SKShaderTileMode.Repeat);

                // Draw the gradient on the rectangle
                canvas.DrawRect(rect, paint);
            }
        }

        public void Click(SKPoint argsLocation)
        {
            text = $"Święta: 🎄 " + argsLocation.ToString();

            engine.RequestRefresh();
        }
    }
}
