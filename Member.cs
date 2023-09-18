using System;
using System.Collections.Generic;

namespace task4;

public partial class Member
{
    public int Id { get; set; }

    public string? Fio { get; set; }

    public int SportId { get; set; }

    public virtual Sport Sport { get; set; } = null!;
}
