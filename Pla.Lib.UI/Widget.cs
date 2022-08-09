using SkiaSharp;

namespace Pla.Lib.UI
{
    public delegate void Clicked(SKPoint point);

    public class Widget
    {
        internal SKRect Bounds = SKRect.Empty;

        public virtual void Draw(SKCanvas canvas, DrawingStyle style)
        {
            using (var BackPainter = new SKPaint()
            {
                Style = SKPaintStyle.Fill,
                Color = new SKColor(128, 128, 128),
            })
            {
                canvas.DrawRect(Bounds, BackPainter);
                canvas.DrawRect(Bounds, style.Front);
            }
        }

        public void OnClick(SKPoint argsLocation)
        {
            ClickedHandler?.Invoke(argsLocation);
        }

        public event Clicked ClickedHandler;

        public virtual SKRect RequestedSize
        {
            get;
        } = default;

        public Frame Parent { get; set; } = null;

    }
}