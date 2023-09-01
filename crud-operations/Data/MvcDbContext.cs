using crud_operations.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace crud_operations.Data;

public class MvcDbContext : DbContext
{
    public MvcDbContext(DbContextOptions<MvcDbContext> options) : base(options)
    {
        
    }

    public DbSet<Employee> Employees { get; set; }
    
}