using SkiaSharp;

namespace Pla.Lib.UI
{

    public class Widget
    {
        internal SKRect Bounds = SKRect.Empty;

        public virtual void Draw(SKCanvas canvas, DrawingStyle style)
        {            
            canvas.DrawRect(Bounds, style.Back);
            canvas.DrawRect(Bounds, style.Front);
        }

        public virtual void OnClick(SKPoint argsLocation)
        {

        }

        public virtual SKPoint RequestedSize
        {
            get;
        } = default;

        public virtual void OnKeyDow(uint key)
        {
            
        }

        public Frame Parent { get; set; } = null;
    }
}