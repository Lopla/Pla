using System;
using System.Collections.Generic;
using SkiaSharp;

namespace Pla.Lib.UI
{
    public enum FrameStyle { Vertical, Horizontal }

    /// <summary>
    /// Container for other controls, handles resizing of objects contained in it. 
    /// </summary>
    public class Frame : Widget, IWidgetContainer
    {
        SKRect canvasSize = default;
        private readonly FrameStyle style;
        private readonly DrawingStyle drawingStyle;
        
        public Frame(
            FrameStyle style = FrameStyle.Vertical,
            DrawingStyle drawingStyle = null)
        {
            this.style = style;
            this.drawingStyle = drawingStyle;
        }

        public Widget FindWidget(SKPoint argsLocation)
        {
            if (Bounds.Contains(argsLocation))
            {
                foreach (var w in Widgets)
                {
                    if (w.Bounds.Contains(argsLocation))
                    {
                        if (w is Frame f)
                        {
                            return f.FindWidget(argsLocation);
                        }
                        return w;
                    }
                }

                return this;
            }


            return null;
            
        }

        List<Widget> Widgets = new List<Widget>();

        public Widget Add(Widget widget)
        {
            widget.Parent = this;
            Widgets.Add(widget);
            return widget;
        }

        public override void Draw(SKCanvas canvas, DrawingStyle style)
        {
            SKRect currentCanvasSize = default;
            canvas.GetLocalClipBounds(out currentCanvasSize);

            if(currentCanvasSize != canvasSize)
            {
                this.canvasSize = currentCanvasSize;
                this.RecalculateControls();
            }

            base.Draw(canvas, drawingStyle ?? style);

            Widgets.ForEach(w => {
                w.Draw(canvas, style);
            });
        }

        private void RecalculateControls()
        {
            if (this.Parent != null)
            {
                // i have a parent no resize for me
                // i will be resized by my parent
                return;
            }
            else
            {
                // resize me
                // i'm the root frame of all
                this.Bounds = this.canvasSize;

                if (this.Bounds.Height > this.RequestedSize.Y)
                {
                    this.Bounds.Bottom = this.RequestedSize.Y;
                }

                if (this.Bounds.Width> this.RequestedSize.X)
                {
                    this.Bounds.Right = this.RequestedSize.X;
                }

                RecalculateChildSizes();
            }            
        }

        private void RecalculateChildSizes()
        {
            int padding = 5;

            SKPoint offset = new SKPoint();

            SKPoint offestDelta = new SKPoint(
                style == FrameStyle.Horizontal ? 1 : 0,
                style == FrameStyle.Vertical ? 1 : 0
            );

            // resize my kids
            foreach (var w in this.Widgets)
            {
                var dY = (padding + padding + w.RequestedSize.Y) ;
                var dX = (padding + padding + w.RequestedSize.X) ;

                var rect = new SKRect(
                    this.Bounds.Left    + offset.X + padding, 
                    this.Bounds.Top     + offset.Y + padding,
                    this.Bounds.Left    + offset.X + dX - padding, 
                    this.Bounds.Top     + offset.Y + dY - padding
                );

                offset.Offset(dX * offestDelta.X , dY * offestDelta.Y);

                w.Bounds = rect;
                if (w is Frame f)
                {
                    f.RecalculateChildSizes();
                }
            }
        }

        public Widget Click(SKPoint argsLocation)
        {
            foreach (var w in Widgets)
            {
                if (w.Bounds.Contains(argsLocation))
                {
                    w.OnClick(argsLocation);
                    return w;
                }
            }

            return null;
        }

        public override SKPoint RequestedSize
        {
            get
            {
                int padding = 5;

                float maxX = 0;
                float maxY = 0;
                float dy = 0;
                float dx = 0;
                foreach (var w in this.Widgets)
                {
                    var ex = (2 * padding + w.RequestedSize.X);
                    var ey = (2 * padding + w.RequestedSize.Y);

                    dy += ey;
                    dx += ex;

                    maxX = Math.Max(maxX, ex);
                    maxY = Math.Max(maxY, ey);
                }

                return 
                    style == FrameStyle.Horizontal ? 
                        new SKPoint(dx, maxY) : new SKPoint(maxX, dy);
            }
        }
    }
}