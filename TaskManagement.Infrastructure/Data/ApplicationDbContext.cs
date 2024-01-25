using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Domain.Entities.TaskE> Tasks { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
