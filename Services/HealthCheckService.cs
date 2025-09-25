using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using PositiveStudentManagement.Data;

namespace PositiveStudentManagement.Services
{
    public class DatabaseHealthCheck : IHealthCheck
    {
        private readonly ApplicationDbContext _context;

        public DatabaseHealthCheck(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                await _context.Database.CanConnectAsync(cancellationToken);
                
                var studentCount = await _context.Students.CountAsync(cancellationToken);
                
                return HealthCheckResult.Healthy($"Database is healthy. Total students: {studentCount}");
            }
            catch (Exception ex)
            {
                return HealthCheckResult.Unhealthy("Database is unhealthy", ex);
            }
        }
    }

    public class ApplicationHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            try
            {
                var memoryUsage = GC.GetTotalMemory(false);
                var memoryUsageMB = memoryUsage / 1024 / 1024;
                
                var healthData = new Dictionary<string, object>
                {
                    { "memory_usage_mb", memoryUsageMB },
                    { "uptime", Environment.TickCount64 / 1000 },
                    { "timestamp", DateTime.UtcNow }
                };

                return Task.FromResult(HealthCheckResult.Healthy("Application is healthy", healthData));
            }
            catch (Exception ex)
            {
                return Task.FromResult(HealthCheckResult.Unhealthy("Application is unhealthy", ex));
            }
        }
    }
}
