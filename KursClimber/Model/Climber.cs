using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;

namespace KursClimber.Model;

[INotifyPropertyChanged]
public partial class Climber
{
    
    public long ClimberId { get; set; }

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Address { get; set; }

    public virtual ICollection<Participant> Participants { get; set; } = new List<Participant>();
}
