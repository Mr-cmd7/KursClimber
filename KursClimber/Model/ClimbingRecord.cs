using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;

namespace KursClimber.Model;


public partial class ClimbingRecord
{
    public long RecordId { get; set; }

    public long GroupId { get; set; }

    public long MountainId { get; set; }

    public string StartDate { get; set; } = null!;

    public string EndDate { get; set; } = null!;

    public virtual ClimbingGroup Group { get; set; } = null!;

    public virtual Mountain Mountain { get; set; } = null!;
}
