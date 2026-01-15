namespace Arsis.RentalSystem.TerminalShell.BLL.Interface
{
    public interface ITerminalService
    {
        void Start();
        void Stop();
        void SetErrorStatus();
    }
}