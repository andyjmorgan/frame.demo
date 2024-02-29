using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Frame.Demo.Stack.DBContext.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFrameDbContext(this IServiceCollection self, IConfiguration configuration)
    {
        return self.AddDbContext<FrameContext>(options =>
            options.UseNpgsql(configuration.GetValue<string>("PgConnectionString")));
    }
}