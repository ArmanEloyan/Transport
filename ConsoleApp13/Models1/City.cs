using System;
using System.Collections.Generic;

namespace ConsoleApp13.Models1;

public partial class City
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Way> WayCityFroms { get; set; } = new List<Way>();

    public virtual ICollection<Way> WayCityTos { get; set; } = new List<Way>();
}
