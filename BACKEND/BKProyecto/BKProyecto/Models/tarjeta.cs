using System.ComponentModel.DataAnnotations;

namespace BKProyecto.Models
{
    public class tarjeta
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Titular { get; set; }
        [Required]
        public string NumeroTarjeta { get; set; }
        [Required]
        public string FechaExpiracion { get; set; }
        [Required]
        public string cvv { get; set; }
    }
}
