namespace OneClick.UseCases.Intefaces.App
{
    public interface IAppLogger
    {
        void LogInfo(string message);
        void LogError(string message);
        void LogCriticalError(string message);
        void LogTransaction(string message);
        void LogProjectEvent(string message);

    }
}
