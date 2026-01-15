using System;

namespace Arsis.RentalSystem.TerminalShell.MVP.View
{
    public interface IMainWindowView : IView
    {
        event EventHandler<EventArgs> LoadedWindow;
        event EventHandler<EventArgs> ClosedWindow;
    }
}
