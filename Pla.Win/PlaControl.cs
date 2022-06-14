using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pla.Lib;
using Pla.Shared;
using SkiaSharp;

namespace Pla.Win
{
    public partial class PlaControl : UserControl, IEngine
    {
        public PlaControl()
        {
            InitializeComponent();
        }

        public void Init(IContext ctx)
        {
            var sw = new SkiaWrapper(ctx);

            this.skControl.PaintSurface += (sender, args) =>
            {
                sw.OnSkOnPaintSurface(args.Info, args.Surface);
            };

            skControl.Click += (sender, args) =>
            {
                var loc = SKPoint.Empty;
                if (args is MouseEventArgs)
                {
                    loc.X = ((MouseEventArgs)args).X;
                    loc.Y = ((MouseEventArgs)args).Y;
                }
                var tArgs = (loc, loc);
                sw.OnTouch(sender, tArgs);
            };
            
            //// needed to be on for keyboard
            skControl.KeyPress += (sender, args) =>
            {
                var key = args.KeyChar;
                sw.OnKey(key);
            };

            ctx.Init(this);
        }

        public void RequestRefresh()
        {
            this.skControl.Invalidate();
        }

        public DeviceInfo GetDeviceInfo()
        {
            return new DeviceInfo()
            {
                DPI = 300
            };
        }
    }
}
