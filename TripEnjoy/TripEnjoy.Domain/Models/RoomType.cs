using System;
using System.Collections.Generic;

namespace TripEnjoy.Domain.Models;

public partial class RoomType
{
    public int RoomTypeId { get; set; }

    public string RoomTypeName { get; set; } = null!;

    public bool RoomTypeStatus { get; set; }

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
