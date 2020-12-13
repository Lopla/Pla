using Gtk;
using System;
using SkiaSharp.Views.Gtk;
using Pla.Lib;

namespace Pla.Linux
{
    public class App : Window, IEngine {
        private SKDrawingArea drawingArea;

        public App(IContext context) : base("Center")
        {

            SetDefaultSize(250, 200);
            SetPosition(WindowPosition.Center);
            
            DeleteEvent += delegate { Application.Quit(); };
                
            VBox vbox = new VBox(false, 5);
            HBox hbox = new HBox(true, 3);
            
            drawingArea = new SKDrawingArea();
            drawingArea.SetSizeRequest(100,100);
            drawingArea.PaintSurface += (sender, e) => {
                var surface = e.Surface;
                var surfaceWidth = e.Info.Width;
                var surfaceHeight = e.Info.Height;

                var canvas = surface.Canvas;

                
                if(context.GetPainter()==null)
                {
                    canvas.Clear(new SkiaSharp.SKColor(255,255,255) );
                    canvas.Flush ();
                }else
                {
                    context.GetPainter()?.Paint(e.Info, e.Surface);
                }
            };

            drawingArea.AddEvents (
                (int)Gdk.EventMask.ButtonPressMask |
                (int)Gdk.EventMask.TouchMask                
                );
            
            drawingArea.ButtonPressEvent += (sender, e) =>{
                int x, y;
                drawingArea.TranslateCoordinates(drawingArea, (int)e.Event.X, (int)e.Event.Y, out x, out y);
                context.GetControl()?.Click(x, y);
            };
            drawingArea.TouchEvent+= (sender, e) => {
                int x, y;
                drawingArea.TranslateCoordinates(drawingArea, (int)e.Event.X, (int)e.Event.Y, out x, out y);
                context.GetControl()?.Click(x, y);
            };

            Add(drawingArea);

            ShowAll();

            context.Init(this);
        }

        public static void PlaMain(IContext ctx)
        {
            Application.Init();
            new App(ctx);
            Application.Run();
        }

        public void RequestRefresh()
        {
            drawingArea.QueueDraw();
        }
    }
}