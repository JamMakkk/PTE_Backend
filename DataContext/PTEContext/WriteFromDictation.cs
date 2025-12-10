using System;
using System.Collections.Generic;

namespace DataContext.PTEContext;

public partial class WriteFromDictation
{
    public int Id { get; set; }

    public int? SeqNo { get; set; }

    public string Content { get; set; } = null!;

    public bool? IsTested { get; set; }
}
