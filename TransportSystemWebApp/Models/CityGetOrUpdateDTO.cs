using System.ComponentModel.DataAnnotations;

namespace TransportSystemWebApp.Models;

public class CityGetOrUpdateDTO
{
    [Required(ErrorMessage = "Id is required")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [MinLength(1, ErrorMessage = "Name cannot be empty")]
    public string Name { get; set; }
}
