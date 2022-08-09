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
                Color = new SKColor(0, 0, 0),
                TextAlign = SKTextAlign.Center,
            })
            {
                canvas.DrawText(Label, Bounds.MidX, Bounds.MidY, painterb);
            }
        }

        SKRect size = new SKRect(0,0,0,50);
        public override SKRect RequestedSize => size;
    }
}