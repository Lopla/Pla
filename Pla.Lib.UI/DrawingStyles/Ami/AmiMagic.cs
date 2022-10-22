using System.Collections.Generic;
using Pla.Lib.UI.Interfaces;
using Pla.Lib.UI.Widgets.Enums;
using Frame = Pla.Lib.UI.DrawingStyles.Ami.Ornaments.Frame;

namespace Pla.Lib.UI.DrawingStyles.Ami
{
    internal class AmiMagic : IDesign
    {
        public AmiMagic()
        {
            this.Ornaments = new OrnamentsDefinition(this);
            this.Palette = new AmiPalette();
        }
        
        public IOrnamentsPainter Ornaments { get; }
        public IPalette Palette { get; }

        public IOrnamentPainter GetOrnamentPainter(OrnamentType type)
        {
            var d = new Dictionary<OrnamentType, IOrnamentPainter>
            {
                { OrnamentType.WidgetContainer, new Frame(this) },
                { OrnamentType.Active, new Frame(this) },
                { OrnamentType.Modifiable, new Frame(this) },
                { OrnamentType.Visible, new Frame(this) }
            };

            return d[type];
        }
    }
}