using Pla.Lib.UI.DrawingStyles;
using Pla.Lib.UI.Interfaces;
using SkiaSharp;

namespace Pla.Lib.UI.Widgets
{
    public delegate void Clicked(SKPoint point);

    public class Button : BaseTextWidget
    {
        protected override void OnDraw(PaintContext paintContext, IDesign style)
        {
            style.PointAble(paintContext);
        }

        public override void OnClick(SKPoint argsLocation)
        {
            ClickedHandler?.Invoke(argsLocation);
        }
        
        public event Clicked ClickedHandler;
    }
}