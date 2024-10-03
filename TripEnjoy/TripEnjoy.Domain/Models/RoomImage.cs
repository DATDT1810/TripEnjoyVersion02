using System;
using System.Collections.Generic;

namespace TripEnjoy.Domain.Models;

public partial class RoomImage
{
    public int ImageId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public int RoomId { get; set; }

    public virtual Room Room { get; set; } = null!;
}
