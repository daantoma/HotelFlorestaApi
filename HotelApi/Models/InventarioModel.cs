using System;
using System.ComponentModel.DataAnnotations;

namespace HotelApi.Models
{
    public class InventarioModel
    {
        [Key]
        public int IdInventario { get; set; }
        
        public DateTime FechaCompra{ get; set; }
        public decimal CostoProducto { get; set; }
        public string IdProducto { get; set; }
        public int CantidadComprada { get; set; }
        public decimal TotalCompra { get; set; }

        public InventarioModel()
        {
            
        }
        public InventarioModel( decimal costoProducto, string idProducto, int cantidadComprada, decimal totalCompra)
        {
            
            CostoProducto = costoProducto;
            IdProducto = idProducto;
            CantidadComprada = cantidadComprada;
            TotalCompra = totalCompra * cantidadComprada;   
        }   
    }
}