namespace OneClick.Data.Data
{
    public class AppLog
    {
        public long Id { get; set; }
        public string? Message { get; set; }
        public LogType Type { get; set; }
        public LogStatus Status { get; set; }
        public DateTime Date { get; set; }
    }


    public enum LogType
    {
        Error,
        Info,
        CriticalError,
        Transaction,
        ProjectEvent,
    }

    public enum LogStatus
    {
        New,
        Sent,
        Resolved

    }
}
