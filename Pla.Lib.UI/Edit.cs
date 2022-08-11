using SkiaSharp;
using System;
using System.Collections.Generic;

namespace Pla.Lib.UI
{
    public class Edit : Widget
    {
        public string Text = null;
        private bool hasFocus;
        private float TextMaximumH = 20;
        private float TextMaximumW = 100;

        public override void Draw(SKCanvas canvas, DrawingStyle style)
        {
            if(!hasFocus)
                base.Draw(canvas, style);

            using (var painterb = new SKPaint()
            {
                Color = style.Front.Color
            })
            {
                float spacing = 9;
                float fontSize = painterb.FontMetrics.XHeight;
                float textMaximumH = spacing;
                float textMaximumW = TextMaximumW;
                foreach (var t in this.TextLines())
                {
                    textMaximumW = Math.Max(textMaximumW, painterb.MeasureText(t));
                    
                    textMaximumH += fontSize ;

                    canvas.DrawText(t, Bounds.Left, Bounds.Top + textMaximumH, painterb);

                    textMaximumH += spacing;
                }

                if(textMaximumW > TextMaximumW ||  textMaximumH> TextMaximumH)
                {
                    TextMaximumH = textMaximumH;
                    TextMaximumW = textMaximumW;

                    this.Parent.RequestResize();
                }
            } 
        }

        public override void OnKeyDow(uint key)
        {
            this.Text = (this.Text ?? "") + (char)key;

            this.Parent.Invalidate();
        }

        public string[] TextLines()
        {
            return Text?.Split(new char[] { '\r', '\n' });
        }

        public override SKPoint RequestedSize => new SKPoint(TextMaximumW,TextMaximumH);

        public override void GotFocus()
        {
            this.hasFocus = true;
            this.Parent.Invalidate();
        }

        public override void LostFocus()
        {
            this.hasFocus = false;
            this.Parent.Invalidate();
        }
    }
}