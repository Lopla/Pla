using Pla.Lib.UI.Interfaces;
using SkiaSharp;

namespace Pla.Lib.UI
{
    public class Widget
    {
        internal SKRect Bounds = SKRect.Empty;
        
        public IWidgetContainer Parent { get; set; } = null;

        public virtual SKPoint CalculateRequestedSize(IDesign style)
        {
            return SKPoint.Empty;
        }

        public virtual void Draw(SKCanvas canvas, IDesign style)
        {
            style.Ornaments.Draw(new PaintContext(this, canvas));
        }

        public virtual void OnClick(SKPoint argsLocation)
        {
        }

        public virtual void OnKeyDow(uint key)
        {
        }

        public virtual void LostFocus()
        {
        }

        public virtual void GotFocus()
        {
        }
    }
}