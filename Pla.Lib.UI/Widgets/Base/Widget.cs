using Pla.Lib.UI.Interfaces;
using SkiaSharp;

namespace Pla.Lib.UI.Widgets.Base
{
    public class Widget
    {
        internal SKRect Bounds = SKRect.Empty;

        public IWidgetContainer Parent { get; set; } = null;

        /// <summary>
        /// If this is true, then keyboard events are send to this control. <see cref="OnKeyDow"/> method is called on each keystroke if this widget is currently selected.
        /// <see cref="Manager.Selected"/> indicates which widget is currently active. Widget can become active when mouse clicks happens.
        /// </summary>
        public bool ConsumeKeys { get;set; } = false;

        public virtual SKPoint CalculateRequestedSize(IDesign style)
        {
            return SKPoint.Empty;
        }

        public virtual void Draw(SKCanvas canvas, IDesign style)
        {
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