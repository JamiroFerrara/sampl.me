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

        app.IgnoreCORS(); //FIX: This is bad!
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        Task.Run(async () => await app.GenerateSwaggerFile());
        app.Run();
    }
}
