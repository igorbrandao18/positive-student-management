namespace PositiveStudentManagement.Services
{
    public interface ILoggingService
    {
        void LogInformation(string message, params object[] args);
        void LogWarning(string message, params object[] args);
        void LogError(string message, Exception? exception = null, params object[] args);
        void LogDebug(string message, params object[] args);
        void LogStudentAction(string action, int studentId, string studentName, string? details = null);
    }
}
