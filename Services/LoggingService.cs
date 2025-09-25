using Microsoft.Extensions.Logging;

namespace PositiveStudentManagement.Services
{
    public class LoggingService : ILoggingService
    {
        private readonly ILogger<LoggingService> _logger;

        public LoggingService(ILogger<LoggingService> logger)
        {
            _logger = logger;
        }

        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }

        public void LogError(string message, Exception? exception = null, params object[] args)
        {
            _logger.LogError(exception, message, args);
        }

        public void LogDebug(string message, params object[] args)
        {
            _logger.LogDebug(message, args);
        }

        public void LogStudentAction(string action, int studentId, string studentName, string? details = null)
        {
            var logMessage = "Student Action: {Action} | Student ID: {StudentId} | Student Name: {StudentName}";
            var args = new object[] { action, studentId, studentName };
            
            if (!string.IsNullOrEmpty(details))
            {
                logMessage += " | Details: {Details}";
                args = args.Concat(new object[] { details }).ToArray();
            }

            _logger.LogInformation(logMessage, args);
        }
    }
}
