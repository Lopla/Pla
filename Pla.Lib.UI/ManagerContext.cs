using Pla.Lib.UI.DrawingStyles.Ami;

namespace Pla.Lib.UI
{
    public class ManagerContext : IContext
    {
        private Manager _manager;

        public void Init(IEngine engine)
        {
            this._manager = new Manager(engine, new AmiMagic());
        }

        public IPainter GetPainter()
        {
            return this._manager;
        }

        public IControl GetControl()
        {
            return this._manager;
        }
    }
}