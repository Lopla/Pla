using Pla.Lib.UI.DrawingStyles;
using SkiaSharp;

namespace Pla.Lib.UI.Widgets
{
    public delegate void Clicked(SKPoint point);

    public class Button : BaseTextWidget
    {
        protected override void OnDraw(PaintContext paintContext, LCars style)
        {
            style.PointAble(paintContext);
        }

        protected override void OnDrawTextLine(PaintContext paintContext, LCars style, string lineOfText)
        {
            style.PointAbleText(paintContext, lineOfText, SKTextAlign.Center);
        }

        public override void OnClick(SKPoint argsLocation)
        {
            ClickedHandler?.Invoke(argsLocation);
        }
        
        public event Clicked ClickedHandler;
    }
}