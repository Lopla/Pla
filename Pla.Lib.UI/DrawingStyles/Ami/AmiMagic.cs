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
                { OrnamentType.WidgetContainer, new Frame(this, accentAround: false, Frame.FrameStyle.Sunken) },
                { OrnamentType.Active, new Frame(this, true, Frame.FrameStyle.Raised) },
                { OrnamentType.Modifiable, new Frame(this, true, Frame.FrameStyle.Sunken) },
                { OrnamentType.Visible, new Frame(this, false, Frame.FrameStyle.None) }
            };

            return d[type];
        }
    }
}