using System.Collections.Generic;
using Pla.Lib.UI.DrawingStyles;
using Pla.Lib.UI.Interfaces;
using Pla.Lib.UI.Widgets;
using Pla.Lib.UI.Widgets.Base;
using Pla.Lib.UI.Widgets.Enums;
using Pla.Lib.UI.Widgets.Events;
using SkiaSharp;

namespace Pla.Lib.UI
{
    public class Manager : IControl, IPainter, IWidgetContainer
    {
        private readonly IEngine _painter;
        private readonly Frame _rootFrame = new Frame();
        private readonly IDesign _style;

        public Manager(IEngine painter, IDesign style)
        {
            _painter = painter;
            _style = style;
            _rootFrame.Parent = this;
        }

        public Widget Selected { get; set; }

        public void KeyDown(uint key)
        {
            if(this.Selected!=null && this.Selected.ConsumeKeys)
            {
                Selected?.OnKeyDow(key);
            }
            else
            {
                if(key=='\t')
                {
                    this.Selected = this._rootFrame.FindFirstSelecatableWidget();
                }
            }
        }

        public void Click(SKPoint argsLocation)
        {
            var w = _rootFrame.FindWidget(argsLocation);

            Selected?.LostFocus();
            Selected = w;
            OnWidgetSelected?.Invoke(w);
            w?.GotFocus();
            w?.OnClick(argsLocation);
        }

        public void Paint(SKImageInfo info, SKSurface surface)
        {
            surface.Canvas.Clear(_style.Palette.Color(Styling.ScreenBackground));

            _rootFrame.Draw(surface.Canvas, _style);

            surface.Canvas.Flush();
        }

        public IEnumerable<Widget> Widgets => _rootFrame.Widgets;

        public Widget Add(Widget widget)
        {
            _rootFrame.Add(widget);
            return widget;
        }

        public void Invalidate()
        {
            _painter.RequestRefresh();
        }

        public void RequestResize()
        {
            _rootFrame.RecalculateControls();
            Invalidate();
        }

        public FrameStyle Orientation => _rootFrame.Orientation;

        public event WidgetSelected OnWidgetSelected;

        public IDesign GetStyle()
        {
            return _style;
        }

        public void RequestClose()
        {
            _painter.RequestQuit();
        }

        public Widget FindFirstSelecatableWidget()
        {
            return _rootFrame.FindFirstSelecatableWidget();
        }
    }
}