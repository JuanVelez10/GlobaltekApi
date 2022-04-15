using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Persistence.DataBase
{
    public class GlobaltekContext : DbContext
    {

        public GlobaltekContext(DbContextOptions<GlobaltekContext> options): base(options){ }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Message>().HasKey(table => new {
                table.Code,
                table.MessageType
            });

        }

        public virtual DbSet<Product>? Product { get; set; }
        public virtual DbSet<Person>? Person { get; set; }
        public virtual DbSet<Discount>? Discount { get; set; }
        public virtual DbSet<Tax>? Tax { get; set; }
        public virtual DbSet<Bill>? Bill { get; set; }
        public virtual DbSet<BillDetail>? BillDetail { get; set; }
        public virtual DbSet<Message>? Message { get; set; }

    }


}
