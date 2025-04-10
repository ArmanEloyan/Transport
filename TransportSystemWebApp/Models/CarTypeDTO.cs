using System.ComponentModel.DataAnnotations;

namespace TransportSystemWebApp.Models
{
    public class CarTypeDTO
    {
        [Required(ErrorMessage = "Name is required")]
        [MinLength(1, ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }

        [Range(1.0, double.MaxValue, ErrorMessage = "Coefficient cant be less then 1.0")]
        public double Coefficent { get; set; }
    }
}
