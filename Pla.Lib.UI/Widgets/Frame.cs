using System.Collections.Generic;
using Pla.Lib.UI.DrawingStyles.LCars.ActiveElements;
using Pla.Lib.UI.Interfaces;
using Pla.Lib.UI.Widgets.Base;
using Pla.Lib.UI.Widgets.Enums;
using SkiaSharp;

namespace Pla.Lib.UI.Widgets
{
    /// <summary>
    ///     Container for other controls, handles resizing of objects contained in it.
    /// </summary>
    public class Frame : Widget, IWidgetContainer
    {
        private readonly OrnamentType _ornamentStyle;
        private readonly FrameActiveElement _painter;

        private readonly List<Widget> _widgets = new List<Widget>();

        private SKRect _canvasSize;

        public Frame(FrameStyle style = FrameStyle.Vertical, OrnamentType ornamentStyle = OrnamentType.WidgetContainer)
        {
            _ornamentStyle = ornamentStyle;
            Orientation = style;
            _painter = new FrameActiveElement(this);
        }

        public FrameStyle Orientation { get; }

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
            var padding = 0;

            var offset = new SKPoint();

            var offsetDelta = new SKPoint(
                Orientation == FrameStyle.Horizontal ? 1 : 0,
                Orientation == FrameStyle.Vertical ? 1 : 0
            );

            // resize my kids
            foreach (var w in Widgets)
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

                offset.Offset(dX * offsetDelta.X, dY * offsetDelta.Y);

                w.Bounds = rect;
                if (w is Frame f)
                    f.RecalculateChildSizes(design);
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

        public IEnumerable<Widget> Widgets => _widgets;

        public override void Draw(SKCanvas canvas, IDesign style)
        {
            canvas.GetLocalClipBounds(out var currentCanvasSize);

            if (currentCanvasSize != _canvasSize)
            {
                _canvasSize = currentCanvasSize;
                RecalculateControls();
            }
            
            style
                .Ornaments
                .Draw(new PaintContext(Bounds, canvas), this._ornamentStyle);

            var ornamentedElement =
                style.Ornaments.GetSizeAroundElement(_painter, this._ornamentStyle);
            
            var internalElementBounds = ornamentedElement.OffsetForInternalBounds(Bounds);
            _painter.Draw(new PaintContext(internalElementBounds, canvas));
        }

        public override SKPoint CalculateRequestedSize(IDesign style)
        {
            var ornamentedElement = style.Ornaments.GetSizeAroundElement(_painter, _ornamentStyle);
            return ornamentedElement.RequestedSize();
        }
    }
}