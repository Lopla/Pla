using Gtk;
using System;
using SkiaSharp.Views.Gtk;
using Pla.Lib;

namespace Pla.Linux
{
    public class App : Window {

        private SKDrawingArea drawingArea;

        public App(IContext context) : base("Center")
        {

            SetDefaultSize(250, 200);
            SetPosition(WindowPosition.Center);
            
            DeleteEvent += delegate { Application.Quit(); };
                
            VBox vbox = new VBox(false, 5);
            HBox hbox = new HBox(true, 3);
            
            var engine = new Engine();
            drawingArea = new SKDrawingArea();
            
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

       
    }
}