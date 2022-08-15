using Pla.Lib.UI.Interfaces;

namespace Pla.Lib.UI.DrawingStyles.LCars
{
    /// <summary>
    ///     Warp 10
    /// </summary>
    public class LCarsStyle : IDesign
    {
        public LCarsStyle()
        {
            Ornaments = new LCarsOrnaments(this);
            Palette = new LCarsPalette();
            TextPainter = new LCarsTextPainterActiveElement(Palette);
        }

        public IActiveElementPainter TextPainter { get; set; }

        public IPalette Palette { get; }

        public IOrnamentsPainter Ornaments { get; }
    }
}