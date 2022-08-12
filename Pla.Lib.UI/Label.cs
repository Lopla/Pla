using SkiaSharp;

namespace Pla.Lib.UI
{
    public class Label : Widget
    {
        public string Text { get; set; }

        public override SKPoint RequestedSize => new SKPoint(100, 20);

        public override void Draw(SKCanvas canvas, LCars style)
        {
            style.Text(new PaintContext
            {
                canvas = canvas,
                widgetSize = Bounds
            }, Text, SKTextAlign.Center, true);
        }
    }
}