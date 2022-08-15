using Pla.Lib.UI.Interfaces;
using SkiaSharp;

namespace Pla.Lib.UI.Widgets
{
    public delegate void Clicked(SKPoint point);

    public class Button : BaseTextWidget
    {
        public Button() : base(Ornament.Active)
        {

        }

        public override void OnClick(SKPoint argsLocation)
        {
            ClickedHandler?.Invoke(argsLocation);
        }
        
        public event Clicked ClickedHandler;
    }
}