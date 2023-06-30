using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;

namespace KursClimber.Model;


public partial class ClimbingGroup
{
    public long GroupId { get; set; }

    public long MountainId { get; set; }

    public string Name { get; set; } = null!;

    public string StartTime { get; set; } = null!;

    public virtual ICollection<ClimbingRecord> ClimbingRecords { get; set; } = new List<ClimbingRecord>();

    public virtual Mountain Mountain { get; set; } = null!;

    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();
}
