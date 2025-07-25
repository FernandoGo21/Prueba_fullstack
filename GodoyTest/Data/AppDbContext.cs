using GodoyTest.DTOs;
using GodoyTest.Models;
using Microsoft.EntityFrameworkCore;
namespace GodoyTest.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<SearchHistory> SearchHistories { get; set; }
    }
}
