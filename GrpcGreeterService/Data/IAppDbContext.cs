using Microsoft.EntityFrameworkCore;

namespace GrpcGreeterService.Services
{
    public interface IAppDbContext
    {
        DbSet<ProductModel> Campus { get; set; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        

    }
}