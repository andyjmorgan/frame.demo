using Frame.Demo.Stack.DBContext.Classes;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Frame.Demo.Stack.DBContext
{
    public sealed class FrameContext : DbContext
    {
        public DbSet<TemperatureSample> TemperatureSamples { get; set; }
        public FrameContext(DbContextOptions<FrameContext> options) : base(options)
        {
            
        }
    }
}
