using Gtk;
using System;
using SkiaSharp.Views.Gtk;

namespace Pla.Linux
{
    class PlaApp : Window {
    
        public PlaApp() : base("Center")
        {
            SetDefaultSize(250, 200);
            SetPosition(WindowPosition.Center);
            
            DeleteEvent += delegate { Application.Quit(); };
                
            VBox vbox = new VBox(false, 5);
            HBox hbox = new HBox(true, 3);
            
            var drawingArea = new SKDrawingArea();
            drawingArea.SetSizeRequest(100,100);
            drawingArea.PaintSurface += (sender, e) => {
                var surface = e.Surface;
                var surfaceWidth = e.Info.Width;
                var surfaceHeight = e.Info.Height;

                var canvas = surface.Canvas;

                // draw on the canvas

                canvas.Clear(new SkiaSharp.SKColor(255,255,255) );
                canvas.Flush ();
            };


            Add(drawingArea);

            ShowAll();
        }
        
        public static void PlaMain()
        {
            Application.Init();
            new PlaApp();        
            Application.Run();
        }
    }
}