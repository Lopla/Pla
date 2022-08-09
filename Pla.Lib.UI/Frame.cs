using System;
using System.Collections.Generic;
using SkiaSharp;

namespace Pla.Lib.UI
{
    /// <summary>
    /// Container for other controls, handles resizing of objects contained in it. 
    /// </summary>
    public class Frame : Widget
    {
        public Frame()
        {
        }

        public Frame Parent{ get; set; } = null;

        List<Widget> Widgets = new List<Widget>();

        public void Add(Widget widget)
        {
            Widgets.Add(widget);
        }

        SKRect canvasSize = default;

        public override void Draw(SKCanvas canvas, DrawingStyle style)
        {
            SKRect currentCanvasSize = default;
            canvas.GetLocalClipBounds(out currentCanvasSize);

            if(currentCanvasSize != canvasSize)
            {
                this.canvasSize = currentCanvasSize;
                this.RecalculateControls();
            }

            base.Draw(canvas, style);

            Widgets.ForEach(w => {
                w.Draw(canvas, style);
            });
        }

        private void RecalculateControls()
        {
            if (this.Parent != null)
            {
                // i have a parent no resize for me
                return;
            }
            else
            {
                // resize me
                this.Bounds = this.canvasSize;
                RecalculateChildSizes();
            }            
        }

        private void RecalculateChildSizes()
        {
            int padding = 5;
            float offsetY = this.Bounds.Top;

            // resize my kids
            foreach (var w in this.Widgets)
            {
                var dY = padding + padding + w.RequestedSize.Height;

                var rect = new SKRect(
                    this.Bounds.Left    + padding, 
                    this.Bounds.Top     + offsetY + padding,
                    this.Bounds.Right   - padding, 
                    this.Bounds.Top     + offsetY + dY
                );

                offsetY += dY;

                w.Bounds = rect;
                if (w is Frame f)
                {
                    f.RecalculateChildSizes();
                }
            }
        }

        public void Click(SKPoint argsLocation)
        {
            foreach (var w in Widgets)
            {
                if (w.Bounds.Contains(argsLocation))
                {
                    w.OnClick(argsLocation);
                }
            }
        }

        public override SKRect RequestedSize
        {
            get
            {
                int padding = 5;
                float offsetY = 0;

                // resize my kids
                foreach (var w in this.Widgets)
                {
                    offsetY += padding + padding + w.RequestedSize.Height;
                }

                return new SKRect(0,0,0,offsetY);
            }
        }
    }
}