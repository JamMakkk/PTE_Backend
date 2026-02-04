using System;
using System.Collections.Generic;

namespace DataContext.PTEContext;

public partial class MemberRole
{
    public int Id { get; set; }

    public int MemberId { get; set; }

    public int RoleId { get; set; }

    public virtual Member Member { get; set; } = null!;

    public virtual Role Role { get; set; } = null!;
}
