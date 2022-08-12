using System;
using System.Collections.Generic;
using SkiaSharp;

namespace Pla.Lib.UI
{
    public enum FrameStyle
    {
        Vertical,
        Horizontal
    }

    /// <summary>
    ///     Container for other controls, handles resizing of objects contained in it.
    /// </summary>
    public class Frame : Widget, IWidgetContainer
    {
        private readonly List<Widget> _widgets = new List<Widget>();
        private readonly FrameStyle _style;
        private SKRect _canvasSize;

        public Frame(
            FrameStyle style = FrameStyle.Vertical)
        {
            this._style = style;
        }

        public override SKPoint RequestedSize
        {
            get
            {
                var padding = 5;

                float maxX = 0;
                float maxY = 0;
                float dy = 0;
                float dx = 0;
                foreach (var w in _widgets)
                {
                    var ex = 2 * padding + w.RequestedSize.X;
                    var ey = 2 * padding + w.RequestedSize.Y;

                    dy += ey;
                    dx += ex;

                    maxX = Math.Max(maxX, ex);
                    maxY = Math.Max(maxY, ey);
                }

                return
                    _style == FrameStyle.Horizontal ? new SKPoint(dx, maxY) : new SKPoint(maxX, dy);
            }
        }

        public void Invalidate()
        {
            Parent.Invalidate();
        }

        public Widget Add(Widget widget)
        {
            widget.Parent = this;
            _widgets.Add(widget);
            Parent.RequestResize();
            return widget;
        }

        public void RequestResize()
        {
            if (Parent is Manager)
            {
                RecalculateControls();
                Invalidate();
            }
            else
            {
                Parent.RequestResize();
            }
        }

        public Widget FindWidget(SKPoint argsLocation)
        {
            if (Bounds.Contains(argsLocation))
            {
                foreach (var w in _widgets)
                    if (w.Bounds.Contains(argsLocation))
                    {
                        if (w is Frame f) return f.FindWidget(argsLocation);
                        return w;
                    }

                return this;
            }

            return null;
        }

        public override void Draw(SKCanvas canvas, LCars style)
        {
            SKRect currentCanvasSize = default;
            canvas.GetLocalClipBounds(out currentCanvasSize);

            if (currentCanvasSize != _canvasSize)
            {
                _canvasSize = currentCanvasSize;
                RecalculateControls();
            }

            if (!(this.Parent is Manager))
            {
                style.Visible(new PaintContext
                {
                    canvas = canvas,
                    widgetSize = Bounds
                });
            }

            _widgets.ForEach(w => { w.Draw(canvas, style); });
        }

        private void RecalculateControls()
        {
            if (Parent is Manager)
            {
                // resize me
                // i'm the root frame of all
                Bounds = _canvasSize;

                if (Bounds.Height > RequestedSize.Y) Bounds.Bottom = RequestedSize.Y;

                if (Bounds.Width > RequestedSize.X) Bounds.Right = RequestedSize.X;

                RecalculateChildSizes();
            }
        }

        private void RecalculateChildSizes()
        {
            var padding = 5;

            var offset = new SKPoint();

            var offestDelta = new SKPoint(
                _style == FrameStyle.Horizontal ? 1 : 0,
                _style == FrameStyle.Vertical ? 1 : 0
            );

            // resize my kids
            foreach (var w in _widgets)
            {
                var dY = padding + padding + w.RequestedSize.Y;
                var dX = padding + padding + w.RequestedSize.X;

                var rect = new SKRect(
                    Bounds.Left + offset.X + padding,
                    Bounds.Top + offset.Y + padding,
                    Bounds.Left + offset.X + dX - padding,
                    Bounds.Top + offset.Y + dY - padding
                );

                offset.Offset(dX * offestDelta.X, dY * offestDelta.Y);

                w.Bounds = rect;
                if (w is Frame f) f.RecalculateChildSizes();
            }
        }
    }
}