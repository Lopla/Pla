using Gtk;
using System;
using SkiaSharp.Views.Gtk;
using Pla.Lib;
using Pla.Shared;

namespace Pla.Linux
{
    public class App : Window, IEngine {

        private SKDrawingArea _sk = new SKDrawingArea();

        public App(IContext ctx) : base("Center")
        {
            SetDefaultSize(250, 200);
            SetPosition(WindowPosition.Center);
            
            DeleteEvent += delegate { Application.Quit(); };
                
            VBox vbox = new VBox(false, 5);
            HBox hbox = new HBox(true, 3);
            
            ctx.Init(this);

            var sw = new SkiaWrapper(ctx);
            _sk.PaintSurface += (sender, args) => sw.OnSkOnPaintSurface(sender, args);
            _sk.Touch += (sender, args) => sw.OnTouch(sender, args);
            _sk.EnableTouchEvents = true;
            
            Add(drawingArea);

            ShowAll();

            context.Init(new Pla.Shared.Engine());
        }

        public static void PlaMain(IContext ctx)
        {
            Application.Init();
            new App(ctx);
            Application.Run();
        }

        public void RequestRefresh(){
            this._sk.InvalidateSurface();
        }
    }
}