using Pla.Lib.UI.Widgets.Enums;

namespace Pla.Lib.UI.Interfaces
{
    public interface IDesign
    {
        IOrnamentsPainter Ornaments { get; }
        IPalette Palette { get; }

        IOrnamentPainter GetOrnamentPainter(OrnamentType type);
    }
}