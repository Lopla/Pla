using System.Collections.Generic;
using Pla.Lib.UI.Interfaces;
using Pla.Lib.UI.Widgets.Enums;

namespace Pla.Lib.UI.DrawingStyles
{
    public class OrnamentsDefinition : IOrnamentsPainter
    {
        public Dictionary<OrnamentType, IOrnamentPainter> Ornaments;

        public OrnamentsDefinition(IDesign lCarsStyle)
        {
            this.Init(lCarsStyle);
        }

        private void Init(IDesign desingStyle)
        {
            this.Ornaments = new Dictionary<OrnamentType, IOrnamentPainter>();
            foreach (var oType in new []{ OrnamentType.Active, OrnamentType.Modifiable, OrnamentType.Visible, OrnamentType.WidgetContainer})
            {
                this.Ornaments.Add(oType, desingStyle.GetOrnamentPainter(oType));
            }
        }

        public void Draw(PaintContext context,
            OrnamentType ornamentType)
        {
            Ornaments[ornamentType].Draw(context);
        }


        /// <summary>
        ///     Grow ornaments around this element
        /// </summary>
        /// <returns></returns>
        public OrnamentBounds GetSizeAroundElement(IElementPainter internalElement,
            OrnamentType ornamentType)
        {
            return Ornaments[ornamentType].GetSizeAroundElement(internalElement.GetSize());
        }
    }
}