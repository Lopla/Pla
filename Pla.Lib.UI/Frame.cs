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

        SKRect size = default;

        public override void Draw(SKCanvas canvas)
        {
            SKRect currentSize = default;
            canvas.GetLocalClipBounds(out currentSize);

            if(currentSize != size)
            {
                this.size = currentSize;
                this.RecalculateControls();
            }

            base.Draw(canvas);

            Widgets.ForEach(w => {
                w.Draw(canvas);
            });
        }

        private void RecalculateControls()
        {
            if(this.Parent!=null)
            {
                // i have a parent no resize for me
            }
            else{
                // resize me
                this.Bounds = this.size;
            }

            int padding = 5;
            float offsetY = 0;
            // resize my kids
            foreach(var w in this.Widgets)
            {
                    
                var rect = new SKRect(
                    this.size.Left + padding, this.size.Top + offsetY + padding,
                    this.size.Right - padding, this.size.Top + offsetY + padding + w.RequestedSize.Height
                );

                offsetY+=padding+padding+ w.RequestedSize.Height;

                w.Bounds = rect;
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
    }
}