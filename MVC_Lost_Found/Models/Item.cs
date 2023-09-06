using System;
using System.Collections.Generic;

namespace MVC_Lost_Found.Models;

public partial class Item
{
    public int ItemIdPk { get; set; }

    public string Uname { get; set; } = null!;

    public string UserContact { get; set; } = null!;

    public string IteamDesc { get; set; } = null!;

    public string LostLoctionDesc { get; set; } = null!;

    public byte? IsFound { get; set; }

    public string? FloorDetails { get; set; }

    public byte? IsLost { get; set; }

    public byte? IsDeleted { get; set; }
}
