using Pla.Lib.UI.DrawingStyles;
using Pla.Lib.UI.Interfaces;
using SkiaSharp;

namespace Pla.Lib.UI.Widgets
{
    public class Edit : BaseTextWidget
    {
        private int _cursorLocation = 0;
        private bool _hasFocus;


        protected override void OnDraw(PaintContext paintContext, IDesign style)
        {
            paintContext.Focused = _hasFocus;
            style.ModifyAble(paintContext);
        }

        protected override void OnDrawTextLine(PaintContext paintContext, IDesign style, string lineOfText)
        {
            paintContext.Focused = _hasFocus;
            style.ModifyAbleText(paintContext, lineOfText, SKTextAlign.Left);
        }

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