using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AP1_P1_Wandy.Models{
    public class Aportes{
        
        [Key]
         public int AportesId { get; set; } 

         public DateTime Fecha { get; set; }
        
        public string? Persona { get; set; }

        public string? Observacion { get; set; }

        public int Monto { get; set; }
    }
}