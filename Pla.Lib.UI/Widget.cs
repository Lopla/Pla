using Pla.Lib.UI.DrawingStyles;
using Pla.Lib.UI.Interfaces;
using SkiaSharp;

namespace Pla.Lib.UI
{

    public class Widget
    {
        internal SKRect Bounds = SKRect.Empty;

        public virtual void Draw(SKCanvas canvas, LCars style)
        {
            style.Visible(new PaintContext(this, canvas));
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

        public IWidgetContainer Parent { get; set; } = null;

        public virtual void LostFocus()
        {
            
        }

        public virtual void GotFocus()
        {
            
        }
    }
}