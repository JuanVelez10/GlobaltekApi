using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Persistence.DataBase
{
    public class GlobaltekContext : DbContext
    {
        public GlobaltekContext() {}

        public GlobaltekContext(DbContextOptions<GlobaltekContext> options): base(options){ }

        public DbSet<Product> Product { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Discount> Discount { get; set; }
        public DbSet<Product> Tax { get; set; }
        public DbSet<Bill> Bill { get; set; }
        public DbSet<BillDetail> BillDetail { get; set; }

    }


}
