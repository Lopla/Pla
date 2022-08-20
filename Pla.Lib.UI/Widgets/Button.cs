using Pla.Lib.UI.Interfaces;
using Pla.Lib.UI.Widgets.Base;
using Pla.Lib.UI.Widgets.Events;
using SkiaSharp;

namespace Pla.Lib.UI.Widgets
{
    public class Button : TextWidget
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