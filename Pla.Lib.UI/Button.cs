using SkiaSharp;

namespace Pla.Lib.UI
{
    public class Button : Widget
    {
        public string Label = "";

        public override void Draw(SKCanvas canvas, DrawingStyle style)
        {
            base.Draw(canvas, style);

            using (var painterb = new SKPaint()
            {
                Color = style.Front.Color,
                TextAlign = SKTextAlign.Center,
            })
            {
                canvas.DrawText(Label, Bounds.MidX, Bounds.MidY, painterb);
            }
        }

        SKPoint size = new SKPoint(100,32);
        public override SKPoint RequestedSize => size;
    }
}