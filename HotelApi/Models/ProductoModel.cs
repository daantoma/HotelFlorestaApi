using System.ComponentModel.DataAnnotations;

namespace HotelApi.Models
{
    public class ProductoModel
    {
         [Key]
        public string IdProducto { get; set; } 
        public string Nombre     { get; set; }
        public string Tipo       { get; set; }
        public decimal Precio    { get; set; }
        public int Cantidad { get; set; }        
    }
}