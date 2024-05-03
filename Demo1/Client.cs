using System;
using System.Collections.Generic;

namespace Database;

public partial class Client
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
}
