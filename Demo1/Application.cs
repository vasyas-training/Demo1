using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Database;

public partial class Application
{
    public int Id { get; set; }

    public int ClientId { get; set; }

    public int EmployeeId { get; set; }

    public string Name { get; set; } = null!;

    public int DeviceType { get; set; }

    public int Priority { get; set; }

    public DateTime StartedTime { get; set; }

    public DateTime? EndedTime { get; set; }

    public int Price { get; set; }

    public int Status { get; set; }

    public string? Description { get; set; }


    public virtual Client Client { get; set; } = null!;

    public virtual Devicetype DeviceTypeNavigation { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual Status StatusNavigation { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Material> Materials { get; set; } = new List<Material>();
}
