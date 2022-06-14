using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pla.Lib;

namespace Pla.Win
{
    public class App 
    {
        public static void PlaMain(Pla.Lib.IContext ctx)
        {
            var window = new PlaWindow();
            window.Init(ctx);
            Application.Run(window);
        }
    }
}
