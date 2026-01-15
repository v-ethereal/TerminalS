namespace Arsis.RentalSystem.TerminalShell.MVP.View
{
    public interface IOtherServicePayView : IServicePayView, IView
    {
        int ServiceId { get; }
        string PlaceNumber { get; }
    }
}
