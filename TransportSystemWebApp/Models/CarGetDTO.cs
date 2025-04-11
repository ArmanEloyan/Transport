using System.ComponentModel.DataAnnotations;
using TransportSystemWebApp.Entities;

namespace TransportSystemWebApp.Models;

public class CarGetDTO
{
    [Required(ErrorMessage = "Id is required")]
    public int Id { get; set; }

    [Required(ErrorMessage = "CarTypeId is required")]
    public int CarTypeId { get; set; }

    [Required(ErrorMessage = "Mark is required")]
    [MinLength(1, ErrorMessage = "Mark cannot be empty")]
    public string Mark { get; set; }

    [Required(ErrorMessage = "Model is required")]
    [MinLength(1, ErrorMessage = "Model cannot be empty")]
    public string Model { get; set; }

    [Range(1884, 2200, ErrorMessage = "Year must be no earlier than 1884")]
    public int Year { get; set; }

    [Required(ErrorMessage = "CarType is required")]
    public CarType Type { get; set; }
}
