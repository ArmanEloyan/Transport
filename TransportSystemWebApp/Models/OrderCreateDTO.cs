using System.ComponentModel.DataAnnotations;
using TransportSystemWebApp.Entities;

namespace TransportSystemWebApp.Models;

public class OrderCreateDTO
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Email is not valid")]
    public string Email { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    public double Price { get; set; }

    [Required(ErrorMessage = "WayId is required")]
    public int WayId { get; set; }

    [Required(ErrorMessage = "CarId is required")]
    public int CarId { get; set; }

    [Required(ErrorMessage = "TransportType is required")]
    [EnumDataType(typeof(TransportType), ErrorMessage = "Invalid transport type")]
    public TransportType TransportType { get; set; }

    [Required(ErrorMessage = "RecieveDate is required")]
    public DateTime RecieveDate { get; set; }
}
