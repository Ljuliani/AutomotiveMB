using System.ComponentModel.DataAnnotations;

namespace AutomotiveMB.Models
{
    public class Client : IIdentificable
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Enter your Name")]
        public string? Nombre { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Enter your Last Name")]
        public string? Apellido { get; set; }
        [Display(Name = "DNI")]
        [Required(ErrorMessage = "Enter your DNI")]
        public int? Dni { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Enter your Email")]
        public string? Email { get; set; }
        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Enter your Phone")]
        public string? Telefono { get; set; }
        [Display(Name = "Birth Date")]
        [Required(ErrorMessage = "Enter your Birth Date")]
        public DateTime? FechaNacimiento { get; set; }

        public int? VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }


    }
}
