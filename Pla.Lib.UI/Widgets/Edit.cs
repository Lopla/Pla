using Pla.Lib.UI.DrawingStyles;
using Pla.Lib.UI.Interfaces;
using Pla.Lib.UI.Widgets.Base;
using Pla.Lib.UI.Widgets.Enums;
using SkiaSharp;

namespace Pla.Lib.UI.Widgets
{
    public class Edit : TextWidget
    {
        public Edit() : base(OrnamentType.Modifiable)
        {
            _cursorLocation = 0;
        }

        private readonly int _cursorLocation;
        private bool _hasFocus;
        
        public override void OnKeyDow(uint key)
        {
            switch (key)
            {
                case 8: //backspace
                    if (Text.Length > 0)
                        Text = Text.Remove(_cursorLocation, 1);
                    break;
                default:
                    Text = (Text ?? "") + (char)key;
                    break;
            }

            Parent.Invalidate();
        }

        public override void GotFocus()
        {
            _hasFocus = true;
            Parent.Invalidate();
        }

        public override void LostFocus()
        {
            _hasFocus = false;
            Parent.Invalidate();
        }
    }
}