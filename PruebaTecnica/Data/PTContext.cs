using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Entidades;

namespace PruebaTecnica.Data
{
    public class PTContext: DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //   optionsBuilder.UseSqlServer("Server=MSI;Database=PruebaTecnicaDB;Trusted_Connection=True;");
        //}

        public PTContext(DbContextOptions<PTContext> options) : base(options)
        {
        }
        //Entidades
        public DbSet<Product> Products { get; set; }    
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
