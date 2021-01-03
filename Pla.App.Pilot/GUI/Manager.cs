using System;
using System.Collections.Generic;
using Pla.Lib;
using SkiaSharp;

namespace Example.GUI
{
    class Manager
    {
        public Manager(IEngine painter){
            this.painter = painter;            
        }

        List<Widget> Widgets = new List<Widget>();

        private readonly IEngine painter;

        public void Add(Widget widget)
        {
            this.Widgets.Add(widget);
            this.painter.RequestRefresh();
        }

        internal void Draw(SKCanvas canvas)
        {
            this.Widgets.ForEach(w=>w.Draw(canvas));
        }
    }

    public class Widget 
    {
        public SKRect Bounds = SKRect.Empty;
        public virtual void Draw(SKCanvas canvas){
            using( var painter = new SKPaint(){
                    Color = new SKColor(255,255,255)
                })
            {
                canvas.DrawRect(Bounds, painter);
            }
        }
    }

    public class Edit:Widget{
        public string Text = "";

        public override void Draw(SKCanvas canvas)
        {
            using( var paintera = new SKPaint(){
                Color = new SKColor(255,255,255)
                })
            using(var painterb = new SKPaint(){
                Color = new SKColor(0,0,0)
                })
            {
                canvas.DrawRect(Bounds, paintera);
                canvas.DrawText(Text, Bounds.Left, Bounds.MidY, painterb);
            }
        }
    }

    public class Button : Widget
    {
        public string Label = "";

        public override void Draw(SKCanvas canvas)
        {
            base.Draw(canvas);

            using( var paintera = new SKPaint(){
                Color = new SKColor(255,255,255)
                })
            using(var painterb = new SKPaint(){
                Color = new SKColor(0,0,0)
                })
            {
                canvas.DrawRect(Bounds, paintera);
                canvas.DrawText(Label, Bounds.Left, Bounds.MidY, painterb);
            }
        }
    }
}