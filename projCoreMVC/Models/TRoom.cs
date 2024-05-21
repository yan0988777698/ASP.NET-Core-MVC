using System;
using System.Collections.Generic;

namespace projCoreMVC.Models;

public partial class TRoom
{
    public int Fid { get; set; }

    public string? FName { get; set; }

    public decimal? FPrice { get; set; }

    public int? FAmount { get; set; }

    public string? FDescription { get; set; }

    public string? FImagePath { get; set; }
}
