using SkiaSharp;

namespace Example.GUI
{
    public delegate void Clicked(SKPoint point);

    public class Widget
    {
        public SKRect Bounds = SKRect.Empty;

        public virtual void Draw(SKCanvas canvas)
        {
            using (var BackPainter = new SKPaint()
            {
                Style= SKPaintStyle.Fill,
                Color = new SKColor(128, 128, 128),
            })
            using (var front = new SKPaint(){
                Style= SKPaintStyle.Stroke,
                Color = new SKColor(0, 0, 0),
            })
            {
                canvas.DrawRect(Bounds, BackPainter);
                canvas.DrawRect(Bounds, front);
            }
        }

        public void OnClick(SKPoint argsLocation)
        {
            this.ClickedHandler?.Invoke(argsLocation);
        }

        public event Clicked ClickedHandler;
    }
}