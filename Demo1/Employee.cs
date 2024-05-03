using System;
using System.Collections.Generic;

namespace Database;

public partial class Employee
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public int PositionId { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

    public virtual Position Position { get; set; } = null!;
}
