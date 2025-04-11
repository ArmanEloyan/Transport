using System.ComponentModel.DataAnnotations;

namespace TransportSystemWebApp.Models;

public class WayUpdateDTO
{
    [Required(ErrorMessage = "Id is required")]
    public int Id { get; set; }

    [Required(ErrorMessage = "CityFromId is required")]
    public int CityFromId { get; set; }

    [Required(ErrorMessage = "CityToId is required")]
    public int CityToId { get; set; }

    [Range(0, double.MaxValue, ErrorMessage = "StartPrice can't be less than 0")]
    public double StartPrice { get; set; }
}
