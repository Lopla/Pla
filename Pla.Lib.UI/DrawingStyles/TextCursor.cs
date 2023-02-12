using System;
using System.Threading.Tasks;
using Pla.Lib.UI.Widgets.Base;
using SkiaSharp;

namespace Pla.Lib.UI.DrawingStyles
{
    internal class TextCursor
    {
        private readonly Widget _widgetWithText;
        private bool _isActivated;

        public TextCursor(Widget widgetWithText)
        {
            _widgetWithText = widgetWithText;
        }

        public bool Blink { get; set; } = true;

        private async Task Loop()
        {
            while (_isActivated)
            {
                _widgetWithText.Parent.Invalidate();

                Blink = !Blink;

                await Task.Delay(TimeSpan.FromMilliseconds(250));
            }
        }

        public void Draw(PaintContext paintContext)
        {
            if (_isActivated)
                paintContext.Canvas.DrawCircle(paintContext.Bounds.MidX, paintContext.Bounds.MidY, 10, new SKPaint
                {
                    Color =
                        Blink ? new SKColor(100, 100, 100) : new SKColor(0, 0, 0)
                });
        }

        public void Active(bool isActive)
        {
            if (isActive)
            {
                _isActivated = true;
                Loop().GetAwaiter();
            }
            else
            {
                _isActivated = false;
            }
        }
    }
}