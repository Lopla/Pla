using System;
using Example.GUI;
using Pla.Lib;
using SkiaSharp;

namespace Pla.App
{
    public class PilotContext : IPainter, IControl, IContext
    {
        #region Instrumentation
        private IEngine engine;
        private Manager manager;

        public IControl GetControl()
        {
            return this;
        }

        public IPainter GetPainter()
        {
            return this;
        }

        public void Init(IEngine engine)
        {
            this.engine = engine;
            this.manager = new Manager(engine);

            var b = new Button(){
                Bounds=new SKRect(10,10,100, 30),
                Label = "hi",                                                
            };
            this.manager.Add(b);
        }
        #endregion

        string text = "Hello world (click to change)";

        public void Paint(SKImageInfo info, SKSurface surface)
        {
            manager.Draw(surface.Canvas);
        }

        public void Click(SKPoint argsLocation)
        {
            //// change text used to display text on screen
            text = $"You are here: {argsLocation.X} {argsLocation.Y} {engine.GetDeviceInfo().DPI}";

            //// ask GUI to refresh the screen
            engine.RequestRefresh();
        }

        public void KeyDown(uint key)
        {
            Console.WriteLine((char)key);
        }
    }
}
