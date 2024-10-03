using System;
using System.Collections.Generic;

namespace TripEnjoy.Domain.Models;

public partial class Rate
{
    public int RateId { get; set; }

    public int RateValue { get; set; }

    public DateTime RateDate { get; set; }

    public int RoomId { get; set; }

    public int AccountId { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
