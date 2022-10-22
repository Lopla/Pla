using System;
using Pla.Lib.UI.Interfaces;
using Pla.Lib.UI.Widgets.Enums;
using SkiaSharp;

namespace Pla.Lib.UI.DrawingStyles
{
    internal class FrameActiveElement : IActiveElementPainter
    {
        private readonly IWidgetContainer _container;

        private readonly IDesign _style;

        public FrameActiveElement(
            IWidgetContainer widgetContainer, 
            IDesign style)
        {
            _container = widgetContainer;
            _style = style;
        }

        public SKPoint GetSize()
        {
            var padding = 5;

            float maxX = 0;
            float maxY = 0;
            float dy = 0;
            float dx = 0;
            foreach (var w in _container.Widgets)
            {
                var childSize = w.CalculateRequestedSize(_style);
                var ex = 2 * padding + childSize.X;
                var ey = 2 * padding + childSize.Y;

                dy += ey;
                dx += ex;

                maxX = Math.Max(maxX, ex);
                maxY = Math.Max(maxY, ey);
            }

            return
                _container.Orientation == FrameStyle.Horizontal ? new SKPoint(dx, maxY) : new SKPoint(maxX, dy);
        }

        public void Draw(PaintContext paintContext)
        {
            foreach (var w in _container.Widgets) w.Draw(paintContext.Canvas, _style);
        }
    }
}