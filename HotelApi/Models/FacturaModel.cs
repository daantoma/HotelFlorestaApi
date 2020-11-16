using System.ComponentModel.DataAnnotations;

namespace HotelApi.Models
{
    public class FacturaModel
    {
        [Key]
        public int IdFactura    { get; set; }
        public string IdReserva { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total    { get; set; }        
    }
}