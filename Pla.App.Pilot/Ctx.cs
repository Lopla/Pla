using System;
using Example.GUI;
using Pla.Lib;
using SkiaSharp;

namespace Pla.App
{
    public class PlaMainContext : IPainter, IControl, IContext
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

            this.manager.Add(new Button(){
                Bounds=new SKRect(10,10,100, 30),
                Label = "hi"
            });
        }
        #endregion

        string text = "Hello world (click to change)";

        public void Paint(SKImageInfo info, SKSurface surface)
        {
            //// find center point of the screen
            float centerX = info.Width / 2;
            float centerY = info.Height / 2;
            
            var canvas = surface.Canvas;
            //// clear the screen
            canvas.Clear(new SKColor(184, 3, 255));

            //// draw text (from text variable)
            canvas.DrawText(text, centerX, centerY, new SKPaint()
            {
                Color = new SKColor(255, 255, 255),
                Typeface = SKTypeface.FromFamilyName("DejaVu")
            });
            
            this.manager.Draw(canvas);

            //// flush draw actions to canvas
            canvas.Flush();
        }

        public void Click(SKPoint argsLocation)
        {
            //// change text used to display text on screen
            text = $"You are here: {argsLocation.X} {argsLocation.Y}";

            //// ask GUI to refresh the screen
            engine.RequestRefresh();
        }

        public void KeyDown(uint key)
        {
            Console.WriteLine((char)key);
        }
    }
}
