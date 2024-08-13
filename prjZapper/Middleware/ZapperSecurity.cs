
namespace prjZapper
{
    public class ZapperSecurity
    {
        private readonly RequestDelegate _next;
        
        public ZapperSecurity(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Headers["passwordKey"].Contains("ZAPPER"))
            {
                await _next(context);
            }
            else
            {
                context.Response.StatusCode = 403;
                return;
            }
        }
    }
}
