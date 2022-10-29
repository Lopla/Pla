using System;
using System.Threading.Tasks;

namespace Pla.Lib.UI.DrawingStyles
{
    class TextCursor
    {
        private bool isActive = false;
        async Task Loop()
        {
            while (isActive)
            {

                //canvasView.InvalidateSurface();

                await Task.Delay(TimeSpan.FromSeconds(1.0 / 30));
            }
        }

        public void Draw(PaintContext paintContext)
        {

        }
    }
}