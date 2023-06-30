using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;

namespace KursClimber.Model;


public partial class Mountain
{
    public long MountainId { get; set; }

    public string Name { get; set; } = null!;

    public long Height { get; set; }

    public string Country { get; set; } = null!;

    public string Region { get; set; } = null!;

    public virtual ICollection<ClimbingGroup> ClimbingGroups { get; set; } = new List<ClimbingGroup>();

    public virtual ICollection<ClimbingRecord> ClimbingRecords { get; set; } = new List<ClimbingRecord>();
}
