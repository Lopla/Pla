using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pla.Lib;
using Pla.Shared;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace Pla.Mobile
{
    public class PlaGUI : ContentPage, IEngine
    {
        private readonly SKCanvasView _sk = new SKCanvasView();

        public PlaGUI(IContext ctx)
        {
            ctx.Init(this);

            var sw = new SkiaWrapper(ctx);
            _sk.PaintSurface += (sender, args) =>
            {
                sw.OnSkOnPaintSurface(args.Info, args.Surface);
            };
            _sk.Touch += (sender, args) =>
            {
                var location = new SKPoint();
                var t = (location, location);
                sw.OnTouch(sender, t);
            };
            _sk.EnableTouchEvents = true;

            Content = _sk;
        }

        public void RequestRefresh()
        {
            _sk.InvalidateSurface();
        }
    }
}