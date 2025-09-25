using Microsoft.EntityFrameworkCore;
using PositiveStudentManagement.Data;
using PositiveStudentManagement.Models;
using PositiveStudentManagement.Services;
using PositiveStudentManagement.Middleware;
using PositiveStudentManagement.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add Entity Framework
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Application Services
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ILoggingService, LoggingService>();
builder.Services.AddScoped<ICacheService, MemoryCacheService>();

// Add Memory Cache
builder.Services.AddMemoryCache();

// Add Health Checks
builder.Services.AddHealthChecks()
    .AddCheck<DatabaseHealthCheck>("database")
    .AddCheck<ApplicationHealthCheck>("application");

// Add Logging
builder.Services.AddLogging(builder =>
{
    builder.AddConsole();
    builder.AddDebug();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Add Security Headers
app.UseMiddleware<SecurityHeadersMiddleware>();

// Add Error Handling Middleware (temporarily disabled due to DI issues)
// app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Add Health Checks endpoint
app.MapHealthChecks("/health");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Ensure database is created
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.EnsureCreated();
}

// Configure to listen on port 80 for Docker
app.Urls.Add("http://+:80");

app.Run();
