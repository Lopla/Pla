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
            ConsumeKeys = true;

            _textCursor = new TextCursor(this);
        }

        private readonly int _cursorLocation;
        private readonly TextCursor _textCursor;

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
            this._textCursor.Active(true);
            Parent.Invalidate();
        }

        public override void LostFocus()
        {
            this._textCursor.Active(false);
            Parent.Invalidate();

        }

        public override void Draw(SKCanvas canvas, IDesign style)
        {
            base.Draw(canvas, style);
            _textCursor.Draw(new PaintContext(this, canvas, false));
        }
    }
}