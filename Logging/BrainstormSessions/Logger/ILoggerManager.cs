
namespace BrainstormSessions.Logger
{
    public interface ILoggerManager
    {
        void LogInformation(string message);

        void LogDebug(string message);

        void LogError(string message);

        void LogWarning(string message);
    }
}
