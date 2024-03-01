using Frame.Demo.Stack.DBContext.Classes;
using Microsoft.EntityFrameworkCore;

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
