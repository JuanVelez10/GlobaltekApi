using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Persistence.DataBase
{
    public class GlobaltekContext : DbContext
    {
        public GlobaltekContext() {}

        public GlobaltekContext(DbContextOptions<GlobaltekContext> options): base(options){ }

        public DbSet<Product> Product { get; set; }

    }


}
