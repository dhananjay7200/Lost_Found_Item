using System;
using System.Collections.Generic;

namespace MVC_Lost_Found.Models;

public partial class Userdetail
{
    public int UserIdPk { get; set; }

    public string Uname { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string UserPassword { get; set; } = null!;

    public string UserPhonenumber { get; set; } = null!;

    public string UserRole { get; set; } = null!;
}
