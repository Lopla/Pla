using Gtk;
using System;
using SkiaSharp.Views.Gtk;
using SkiaSharp;
using Pla.Lib;
using Pla.Shared;

namespace Pla.Gtk
{
    public class App : Window, IEngine {

        private SKDrawingArea _sk = new SKDrawingArea();

        public App(IContext ctx) : base("Pla")
        {
            SetDefaultSize(320, 240);
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

            _sk.AddEvents(
                (int)Gdk.EventMask.ButtonPressMask |
                (int)Gdk.EventMask.KeyPressMask
                );

            _sk.ButtonPressEvent += (sender, e) =>{
                int x, y;
                _sk.TranslateCoordinates(_sk, (int)e.Event.X, (int)e.Event.Y, out x, out y);
                sw.OnTouch(sender, (new SKPoint(x, y), SKPoint.Empty));
            };

            //// needed to be on for keyboard
            _sk.CanFocus = true;
            _sk.KeyPressEvent+=(sender, e) => {
                var key = e.Event.KeyValue;
                sw.OnKey(key);
            };

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
            _sk.QueueDraw();
        }
    }
}