using System;
using System.Collections.Generic;

namespace ConsoleApp13.Models1;

public partial class Car
{
    public int Id { get; set; }

    public string Mark { get; set; } = null!;

    public string Model { get; set; } = null!;

    public int Year { get; set; }

    public decimal? Coeffiecnt { get; set; }

    public bool IsOperable { get; set; }

    public string? Type { get; set; }
}
