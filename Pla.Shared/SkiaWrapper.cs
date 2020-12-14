using Pla.Lib;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace Pla.Shared
{
    public class SkiaWrapper
    {
        private readonly IContext _context;

        public SkiaWrapper(IContext context)
        {
            _context = context;
        }

        public void OnSkOnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var surface = e.Surface;
            var surfaceWidth = e.Info.Width;
            var surfaceHeight = e.Info.Height;

            var canvas = surface.Canvas;


            if (_context.GetPainter() == null)
            {
                canvas.Clear(new SKColor(255, 255, 255));
                canvas.Flush();
            }
            else
            {
                _context.GetPainter()?.Paint(e.Info, e.Surface);
            }
        }

        public void OnTouch(object sender, SKTouchEventArgs args)
        { 
            _context.GetControl()?.Click(args.Location);
        }
    }
}