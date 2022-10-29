using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Pla.Lib.UI.Widgets.Base;
using SkiaSharp;

namespace Pla.Lib.UI.DrawingStyles
{
    class TextCursor
    {
        private readonly Widget _w;

        public TextCursor(Widget w)
        {
            _w = w;
        }
        private bool isActived = false;
        private TaskAwaiter redrawLoop;

        async Task Loop()
        {
            while (isActived)
            {
                _w.Parent.Invalidate();

                this.Blink = !this.Blink;

                await Task.Delay(TimeSpan.FromMilliseconds(250));
            }
        }

        public bool Blink { get; set; } = true;

        public void Draw(PaintContext paintContext)
        {
            if(isActived)
            {
                paintContext.Canvas.DrawCircle(paintContext.Bounds.MidX, paintContext.Bounds.MidY,10, new SKPaint()
                {
                    Color = 
                        Blink ? 
                            new SKColor(100,100,100):
                            new SKColor(0,0,0),

                });
            }
        }

        public void Active(bool isActive)
        {
            if (isActive)
            {
                isActived = true;
                this.redrawLoop = Loop().GetAwaiter();
            }
            else
            {
                isActived = false;
            }
        }
    }
}