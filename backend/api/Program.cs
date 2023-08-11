internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddCors(options => options.AddDefaultPolicy(builder =>
            builder.WithOrigins("*")));

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        //TODO: Production and Development connection strings
        app.MapSurreal("http://localhost:8000/sql");

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            Microsoft.AspNetCore.Builder.SwaggerBuilderExtensions.UseSwagger(app);
            app.UseSwaggerUI();
        }

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

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
