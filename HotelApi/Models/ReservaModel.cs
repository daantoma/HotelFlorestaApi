using System;
using System.ComponentModel.DataAnnotations;

namespace HotelApi.Models
{
    public class ReservaModel
    {
        [Key]
        public int IdReserva                { get; set; }
        public DateTime FechaInicio         { get; set; }
        public DateTime FechaFin            { get; set; }
        public decimal CantidadPersonas     { get; set; }
        public string IdCliente             { get; set; }
        public string IdHabitacion          { get; set; }
    }
}