using System;
using System.Collections.Generic;

namespace Database;

public partial class Comment
{
    public int Id { get; set; }

    public string CommentText { get; set; } = null!;

    public virtual ICollection<Application> Applications { get; set; } = new List<Application>();
}
