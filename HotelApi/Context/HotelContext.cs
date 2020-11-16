using Microsoft.EntityFrameworkCore;
using HotelApi.Models;

namespace HotelApi.Context
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions options) : base(options)
        {            
        }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<FacturaModel> Facturas {get; set;}
        public DbSet<HabitacionModel> Habitaciones {get; set;}
        public DbSet<InventarioModel> Inventarios {get; set;}
        public DbSet<ProductoModel> Productos {get; set;}
        public DbSet<RecepcionistaModel> Recepcionistas {get; set;}
        public DbSet<ReservaModel> Reservas {get; set;}
        public DbSet<UsersModel> Userss {get; set;}
        public DbSet<HotelApi.Models.CompraModel> CompraModel { get; set; }
    }
}