using System;
using System.Collections.Generic;
using Pla.Lib.UI.Interfaces;
using SkiaSharp;

namespace Pla.Lib.UI.Widgets
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
        private readonly FrameStyle _orientation;
        private readonly List<Widget> _widgets = new List<Widget>();
        private SKRect _canvasSize;

        public Frame(
            FrameStyle style = FrameStyle.Vertical)
        {
            _orientation = style;
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

        public override SKPoint CalculateRequestedSize(IDesign style)
        {
            var padding = 5;

            float maxX = 0;
            float maxY = 0;
            float dy = 0;
            float dx = 0;
            foreach (var w in _widgets)
            {
                var childSize = w.CalculateRequestedSize(style);
                var ex = 2 * padding + childSize.X;
                var ey = 2 * padding + childSize.Y;

                dy += ey;
                dx += ex;

                maxX = Math.Max(maxX, ex);
                maxY = Math.Max(maxY, ey);
            }

            return
                _orientation == FrameStyle.Horizontal ? new SKPoint(dx, maxY) : new SKPoint(maxX, dy);
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

        private Ornament ornamentType = Ornament.Visible;

        public override void Draw(SKCanvas canvas, IDesign style)
        {
            SKRect currentCanvasSize = default;
            canvas.GetLocalClipBounds(out currentCanvasSize);

            if (currentCanvasSize != _canvasSize)
            {
                _canvasSize = currentCanvasSize;
                RecalculateControls();
            }

            if (!(Parent is Manager))
            {
                style.Ornaments.Draw(new PaintContext(this, canvas), ornamentType);
            }

            _widgets.ForEach(w => { w.Draw(canvas, style); });
        }

        private void RecalculateControls()
        {
            if (Parent is Manager m)
            {
                var style = m.GetStyle();

                // resize me
                // i'm the root frame of all
                Bounds = _canvasSize;

                var requestedResize = CalculateRequestedSize(style);

                if (Bounds.Height > requestedResize.Y) Bounds.Bottom = requestedResize.Y;

                if (Bounds.Width > requestedResize.X) Bounds.Right = requestedResize.X;

                RecalculateChildSizes(style);
            }
        }

        private void RecalculateChildSizes(IDesign design)
        {
            var padding = 5;

            var offset = new SKPoint();

            var offestDelta = new SKPoint(
                _orientation == FrameStyle.Horizontal ? 1 : 0,
                _orientation == FrameStyle.Vertical ? 1 : 0
            );

            // resize my kids
            foreach (var w in _widgets)
            {
                var childSize = w.CalculateRequestedSize(design);
                var dY = padding + padding + childSize.Y;
                var dX = padding + padding + childSize.X;

                var rect = new SKRect(
                    Bounds.Left + offset.X + padding,
                    Bounds.Top + offset.Y + padding,
                    Bounds.Left + offset.X + dX - padding,
                    Bounds.Top + offset.Y + dY - padding
                );

                offset.Offset(dX * offestDelta.X, dY * offestDelta.Y);

                w.Bounds = rect;
                if (w is Frame f)
                    f.RecalculateChildSizes(design);
            }
        }
    }
}