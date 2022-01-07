using Microsoft.EntityFrameworkCore;

namespace ErpSaasApi.Models
{
    public class ErpContext : DbContext
    {
        public ErpContext(DbContextOptions options) : base(options)
        { 
        }

        public DbSet<Companies> Companies { get; set; }
        public DbSet<Offices> Offices { get; set; }
        public DbSet<WareHouses> WareHouses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seedin comapiens
            modelBuilder.Entity<Companies>().HasData(new Companies
            {
                Id = 1,
                BusinessName = "Empresa Demo",
                BusinessId = "DEMO890224455",
                BusinnesClasification = "601 - General de Impuestos",
                Addrees = "Direccion 1",
                Address2 = "Direccion 2",
                Country = "Mexico",
                State = "Jalisco",
                City = "Guadalajara",
                ZipCode = "44720"
            }
            );

            modelBuilder.Entity<Offices>().HasData(new Offices
            {
                Id = 1,
                Name = "Oficina Matriz",
                Type = "Matriz",
                Addrees = "Direccion 1",
                Address2 = "Direccion 2",
                Country = "Mexico",
                State = "Jalisco",
                City = "Guadalajara",
                ZipCode = "44750",
                Status = 1
            });

            modelBuilder.Entity<WareHouses>().HasData(new WareHouses
            {
                Id = 1,
                Name = "Almacen General",
                Type = "Fisico",
                Status = 1,
                OfficeId = 1
            });
        }
        
    }
}
