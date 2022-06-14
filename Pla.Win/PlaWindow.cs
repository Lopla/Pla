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

namespace Pla.Win
{
    public partial class PlaWindow : Form
    {
        public PlaWindow()
        {
            InitializeComponent();

        }

        public void Init(IContext ctx)
        {
            this.plaControl1.Init(ctx);

            if (false)
            {
                this.BackColor = Color.LimeGreen;
                this.TransparencyKey = Color.LimeGreen;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            }
        }
    }
}
