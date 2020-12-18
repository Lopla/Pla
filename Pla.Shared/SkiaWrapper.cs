using System;
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

        public void OnSkOnPaintSurface(SKImageInfo info, SKSurface surface)
        {
            if (_context.GetPainter() == null)
            {
                var canvas = surface.Canvas;
                canvas.Clear(new SKColor(255, 255, 255));
                canvas.Flush();
            }
            else
            {
                _context.GetPainter()?.Paint(info, surface);
            }
        }

        public void OnTouch(object sender, (SKPoint location, SKPoint loc2) data)
        { 
            _context.GetControl()?.Click(data.location);
        }
    }
}