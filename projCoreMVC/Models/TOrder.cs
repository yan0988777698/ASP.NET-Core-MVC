using System;
using System.Collections.Generic;

namespace projCoreMVC.Models;

public partial class TOrder
{
    public int FId { get; set; }

    public string? FDate { get; set; }

    public decimal? FPrice { get; set; }

    public int? FRoomId { get; set; }

    public int? FCustomerId { get; set; }
}
