using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;

namespace KursClimber.Model;


public partial class Participant
{
    public long ParticipantId { get; set; }

    public long GroupId { get; set; }

    public long ClimberId { get; set; }

    public virtual Climber Climber { get; set; } = null!;

    public virtual ClimbingGroup Group { get; set; } = null!;
}
