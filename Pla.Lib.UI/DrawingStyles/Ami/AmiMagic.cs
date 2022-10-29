using System.Collections.Generic;
using Pla.Lib.UI.Interfaces;
using Pla.Lib.UI.Widgets.Enums;
using SolidFrame = Pla.Lib.UI.DrawingStyles.Ami.Ornaments.SolidFrame;

namespace Pla.Lib.UI.DrawingStyles.Ami
{
    public class AmiMagic : IDesign
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
                { OrnamentType.WidgetContainer, new SolidFrame(this, accentAround: false, SolidFrame.FrameStyle.Sunken) },
                { OrnamentType.Active, new SolidFrame(this, true, SolidFrame.FrameStyle.Raised) },
                { OrnamentType.Modifiable, new SolidFrame(this, true, SolidFrame.FrameStyle.Sunken) },
                { OrnamentType.Visible, new SolidFrame(this, false, SolidFrame.FrameStyle.None) }
            };

            return d[type];
        }
    }
}