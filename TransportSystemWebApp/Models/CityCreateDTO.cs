using System.ComponentModel.DataAnnotations;

namespace TransportSystemWebApp.Models
{
    public class CityCreateDTO
    {
        [Required(ErrorMessage = "Name is required")]
        [MinLength(1, ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }
    }
}
