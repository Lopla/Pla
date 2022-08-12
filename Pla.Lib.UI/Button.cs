using SkiaSharp;

namespace Pla.Lib.UI
{

    public delegate void Clicked(SKPoint point);

    public class Button : Widget
    {
        public string Label = "";

        public override void Draw(SKCanvas canvas, IDrawingStyle style)
        {
            base.Draw(canvas, style);

            var p = new PaintContext()
            {
                canvas = canvas,
                widgetSize = this.Bounds
            };

            style.PointAble(p);
            style.Text(p, Label, SKTextAlign.Center);
        }

        SKPoint size = new SKPoint(100,32);
        public override SKPoint RequestedSize => size;

        public override void OnClick(SKPoint argsLocation)
        {
            ClickedHandler?.Invoke(argsLocation);
        }


        public event Clicked ClickedHandler;

    }
}