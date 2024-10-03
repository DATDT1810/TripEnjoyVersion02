using System;
using System.Collections.Generic;

namespace TripEnjoy.Domain.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public int HotelId { get; set; }

    public string RoomTitle { get; set; } = null!;

    public int RoomTypeId { get; set; }

    public int RoomQuantity { get; set; }

    public int RoomStatusId { get; set; }

    public decimal RoomPrice { get; set; }

    public string? RoomDescription { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Hotel Hotel { get; set; } = null!;

    public virtual ICollection<Rate> Rates { get; set; } = new List<Rate>();

    public virtual ICollection<RoomImage> RoomImages { get; set; } = new List<RoomImage>();

    public virtual RoomStatus RoomStatus { get; set; } = null!;

    public virtual RoomType RoomType { get; set; } = null!;
}
