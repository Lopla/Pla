using Pla.Lib.UI.DrawingStyles;
using SkiaSharp;

namespace Pla.Lib.UI.Widgets
{
    public delegate void Clicked(SKPoint point);

    public class Button : Widget
    {
        public string Label = "";

        public override SKPoint RequestedSize { get; } = new SKPoint(100, 32);

        public override void Draw(SKCanvas canvas, LCars style)
        {
            base.Draw(canvas, style);

            var p = new PaintContext(this, canvas);

            style.PointAble(p, Label);
        }

        public override void OnClick(SKPoint argsLocation)
        {
            ClickedHandler?.Invoke(argsLocation);
        }
        
        public event Clicked ClickedHandler;
    }
}