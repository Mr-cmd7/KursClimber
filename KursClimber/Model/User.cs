using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;

namespace KursClimber.Model;


public partial class User
{
    public long UserId { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;
}
