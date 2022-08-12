using System;
using Pla.Lib.UI.DrawingStyles;
using SkiaSharp;

namespace Pla.Lib.UI.Widgets
{
    public class Edit : Widget
    {
        public string Text = null;

        private bool _hasFocus;
        private float _textMaximumH = 20;
        private float _textMaximumW = 100;

        public override void Draw(SKCanvas canvas, LCars style)
        {
            if(!_hasFocus)
                base.Draw(canvas, style);

            using (var painterb = new SKPaint())
            {
                float spacing = 9;
                float fontSize =
                    style.SizeWithText("a").Y;

                float textMaximumH = spacing;
                float textMaximumW = _textMaximumW;
                foreach (var t in this.TextLines())
                {
                    textMaximumW = Math.Max(textMaximumW, style.SizeWithText(t).X);
                    
                    textMaximumH += fontSize ;

                    style.ModifyAble(new PaintContext(this, canvas, this._hasFocus), Text, SKTextAlign.Left);
                    
                    textMaximumH += spacing;
                }

                if(textMaximumW > _textMaximumW ||  textMaximumH> _textMaximumH)
                {
                    _textMaximumH = textMaximumH;
                    _textMaximumW = textMaximumW;

                    this.Parent.RequestResize();
                }
            } 
        }

        public override void OnKeyDow(uint key)
        {
            switch(key)
            {
                case 8://backspace
                    if(this.Text.Length > 0)
                        this.Text = this.Text.Remove(cursorLocation, 1);
                    break;
                default: 
                    this.Text = (this.Text ?? "") + (char)key;
                    break;
            }
            this.Parent.Invalidate();
        }

        int cursorLocation = 0;

        public string[] TextLines()
        {
            return Text?.Split(new char[] { '\r', '\n' });
        }

        public override SKPoint RequestedSize => new SKPoint(_textMaximumW,_textMaximumH);

        public override void GotFocus()
        {
            this._hasFocus = true;
            this.Parent.Invalidate();
        }

        public override void LostFocus()
        {
            this._hasFocus = false;
            this.Parent.Invalidate();
        }
    }
}