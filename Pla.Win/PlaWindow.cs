using Pla.Lib;

namespace Pla.Win;

public partial class PlaWindow : Form
{
    private Color _bforeTransparent;

    public PlaWindow()
    {
        InitializeComponent();
    }

    public void Init(IContext ctx)
    {
        plaControl1.Init(ctx);
    }

    public void SetTransparent()
    {
        BackColor = Color.LimeGreen;
        TransparencyKey = BackColor;
        FormBorderStyle = FormBorderStyle.None;
    }

    public void DisableTransparent()
    {
        BackColor = this._bforeTransparent;
        TransparencyKey = Color.LimeGreen;
        FormBorderStyle = FormBorderStyle.Sizable;
    }

}