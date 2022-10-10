using Pla.Lib;

namespace Pla.Win;

public partial class PlaWindow : Form
{
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
        TransparencyKey = Color.LimeGreen;
        FormBorderStyle = FormBorderStyle.None;
    }
}