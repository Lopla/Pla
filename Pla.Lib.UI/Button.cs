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

        public override void OnClick(SKPoint argsLocation)
        {
            ClickedHandler?.Invoke(argsLocation);
        }


        public event Clicked ClickedHandler;

    }
}