using Microsoft.EntityFrameworkCore;

namespace GrpcGreeterService.Services
{
    public partial class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.SetCommandTimeout(6000);
        }
        
        public DbSet<ProductModel> Campus { get; set; }
        
    }
   

}