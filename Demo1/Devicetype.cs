using System;
using System.Collections.Generic;

namespace Database;

public partial class Devicetype
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
}
