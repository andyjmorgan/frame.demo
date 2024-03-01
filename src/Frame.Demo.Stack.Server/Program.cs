using Frame.Demo.Stack.DBContext.Extensions;
using Frame.Demo.Stack.Logging;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddFrameDbContext(builder.Configuration);
        builder.Services.AddAutoMapper(typeof(Program));

        builder.AddContainerLogging();
        var app = builder.Build();

        app.UseDefaultFiles();
        app.UseStaticFiles();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseAuthorization();

        app.MapControllers();

        app.MapFallbackToFile("/index.html");

        app.Run();
    }
}