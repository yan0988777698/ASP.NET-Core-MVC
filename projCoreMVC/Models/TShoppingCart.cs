using System;
using System.Collections.Generic;

namespace projCoreMVC.Models;

public partial class TShoppingCart
{
    public int Fid { get; set; }

    public string? FDate { get; set; }

    public int? FCustomerId { get; set; }

    public int? FAmount { get; set; }

    public int? FRoomId { get; set; }

    public decimal? FPrice { get; set; }
}
