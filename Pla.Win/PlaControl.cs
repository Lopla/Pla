using Pla.Lib;
using Pla.Shared;
using SkiaSharp;

namespace Pla.Win;

public partial class PlaControl : UserControl, IEngine
{
    public PlaControl()
    {
        InitializeComponent();
    }

    public bool RequestTransparentWindow()
    {
        if (this.Parent is PlaWindow wnd)
        {
            wnd.SetTransparent();
            return true;
        }

        return false;
    }

    public void RequestRefresh()
    {
        skControl.Invalidate();
    }

    public DeviceInfo GetDeviceInfo()
    {
        return new DeviceInfo
        {
            DPI = skControl.DeviceDpi
        };
    }

    public void Init(IContext ctx)
    {
        var sw = new SkiaWrapper(ctx);

        skControl.PaintSurface += (sender, args) =>
        {
            sw.OnSkOnPaintSurface(args.Info, args.Surface);
        };

        skControl.Click += (sender, args) =>
        {
            var loc = SKPoint.Empty;
            if (args is MouseEventArgs)
            {
                loc.X = ((MouseEventArgs) args).X;
                loc.Y = ((MouseEventArgs) args).Y;
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

        var keyCodes = new []{Keys.Down, Keys.Up, Keys.Left, Keys.Right};

        skControl.KeyDown += (sender, args) =>
        {
            if(keyCodes.Contains(args.KeyCode))
                sw.OnControlKey(args.KeyValue);
        };

        skControl.PreviewKeyDown += (sender, args) =>
        {
            if(keyCodes.Contains(args.KeyCode))
            {
                args.IsInputKey = true;
            }
        };
        ctx.Init(this);
    }

    public void RequestQuit()
    {
        Application.Exit();
    }
}