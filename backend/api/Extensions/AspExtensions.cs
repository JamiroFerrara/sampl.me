public static class AspExtensions
{
    public static WebApplication IgnoreCORS(this WebApplication app)
    {
        app.Use(async (context, next) =>
        {
            if (context.Request.Method == "OPTIONS")
            {
                context.Response.StatusCode = 200;

                await WriteCorsAsync(context);

                await context.Response.WriteAsync("");
            }
            else
            {
                context.Response.OnStarting(WriteCorsAsync, context);

                await next(context);
            }

            static Task WriteCorsAsync(object state)
            {
                var context = (HttpContext)state;

                context.Response.Headers.Add("Access-Control-Allow-Origin", context.Request.Headers.Origin);
                context.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
                context.Response.Headers.Add("Access-Control-Allow-Methods", string.Join(", ", new[] { context.Request.Method }.Union(context.Request.Headers.AccessControlRequestMethod.Select(v => v))));
                context.Response.Headers.Add("Access-Control-Allow-Headers", string.Join(", ", context.Request.Headers.Select(p => p.Key).Union(context.Request.Headers.AccessControlRequestHeaders.Select(v => v))));

                return Task.CompletedTask;
            }
        });

        app.UseCors(b => b
        .AllowAnyMethod()
        .AllowAnyMethod()
        .AllowAnyHeader());
        return app;
    }
}
