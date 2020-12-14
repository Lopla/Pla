using Gtk;
using System;
using SkiaSharp.Views.Gtk;
using SkiaSharp;
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
            _sk.PaintSurface += (sender, e) => 
            {
                sw.OnSkOnPaintSurface(e.Info, e.Surface);
            };
            _sk.TouchEvent+= (sender,e) =>{
                var loc = SKPoint.Empty;

                var tArgs = ( loc, loc ); 
                sw.OnTouch(sender, tArgs  );  
                
            };
            _sk.AddEvents( (int)Gdk.EventMask.TouchMask   );
            
            //_sk.  .Touch += (sender, args) => sw.OnTouch(sender, args);
            //_sk.EnableTouchEvents = true;
            
            Add(_sk);

            ShowAll();

        }

        public static void PlaMain(IContext ctx)
        {
            Application.Init();
            new App(ctx);
            Application.Run();
        }

        public void RequestRefresh(){
            
        }
    }
}