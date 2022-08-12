using SkiaSharp;

namespace Pla.Lib.UI
{
    public class Label:Widget
    {
        public Label()
        {
        }

        public override void Draw(SKCanvas canvas, IDrawingStyle style)
        {
            base.Draw(canvas, style);

            using (var painterb = new SKPaint()
            {
                Color = style.Front.Color,
                TextAlign = SKTextAlign.Center,
            })
            {
                canvas.DrawText(Text, Bounds.MidX, Bounds.MidY, painterb);
            }
        }

        public string Text { get; set; }

        public override SKPoint RequestedSize => new SKPoint(100,20);
    }
}