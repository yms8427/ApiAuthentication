using BilgeAdam.SecuredApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BilgeAdam.SecuredApp.Data
{
    public class NorthwindContext : DbContext
    {
        public NorthwindContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}