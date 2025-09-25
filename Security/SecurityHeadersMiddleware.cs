namespace PositiveStudentManagement.Security
{
    public class SecurityHeadersMiddleware
    {
        private readonly RequestDelegate _next;

        public SecurityHeadersMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Add security headers
            context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
            context.Response.Headers.Add("X-Frame-Options", "DENY");
            context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
            context.Response.Headers.Add("Referrer-Policy", "strict-origin-when-cross-origin");
            context.Response.Headers.Add("Permissions-Policy", "geolocation=(), microphone=(), camera=()");
            
            // Content Security Policy
            var csp = "default-src 'self'; " +
                     "script-src 'self' 'unsafe-inline' https://cdn.jsdelivr.net; " +
                     "style-src 'self' 'unsafe-inline' https://cdn.jsdelivr.net; " +
                     "img-src 'self' data: https:; " +
                     "font-src 'self' https://cdn.jsdelivr.net; " +
                     "connect-src 'self'; " +
                     "frame-ancestors 'none';";
            
            context.Response.Headers.Add("Content-Security-Policy", csp);

            await _next(context);
        }
    }
}
