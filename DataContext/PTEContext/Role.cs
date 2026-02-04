using System;
using System.Collections.Generic;

namespace DataContext.PTEContext;

public partial class Role
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public virtual ICollection<MemberRole> MemberRoles { get; set; } = new List<MemberRole>();
}
