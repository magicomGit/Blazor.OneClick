using OneClick.Data.Data;
using OneClick.UseCases.Intefaces.App;

namespace OneClick.Data.Helpers
{
    public class AppLogger : IAppLogger
    {
        ApplicationDbContext _context;
        public AppLogger(ApplicationDbContext context)
        {
            _context = context;
        }

        public  void LogInfo(string message)
        {
            _context.Add(new AppLog { Date = DateTime.UtcNow, Type = LogType.Info, Message = message });
            _context.SaveChanges();
        }

        public  void LogError(string message)
        {
            _context.Add(new AppLog { Date = DateTime.UtcNow, Type = LogType.Error, Message = message });
            _context.SaveChanges();
        }

        public  void LogCriticalError(string message)
        {
            _context.Add(new AppLog { Date = DateTime.UtcNow, Type = LogType.CriticalError, Message = message });
            _context.SaveChanges();
        }
        public  void LogTransaction(string message)
        {
            _context.Add(new AppLog { Date = DateTime.UtcNow, Type = LogType.Transaction, Message = message });
            _context.SaveChanges();
        }

        public  void LogProjectEvent( string message)
        {
            _context.Add(new AppLog { Date = DateTime.UtcNow, Type = LogType.ProjectEvent, Message = message });
            _context.SaveChanges();
        }
    }
}
