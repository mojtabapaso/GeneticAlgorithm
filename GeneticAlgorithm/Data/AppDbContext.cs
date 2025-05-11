using GeneticAlgorithm.Models;
using Microsoft.EntityFrameworkCore;

namespace GeneticAlgorithm.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<CompanyFinancial> CompanyFinancials { get; set; }
    }

}
