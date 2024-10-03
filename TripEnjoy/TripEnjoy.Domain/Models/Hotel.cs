using System;
using System.Collections.Generic;

namespace TripEnjoy.Domain.Models;

public partial class Hotel
{
    public int HotelId { get; set; }

    public string HotelName { get; set; } = null!;

    public string HotelAddress { get; set; } = null!;

    public string HotelPhone { get; set; } = null!;

    public string HotelDescription { get; set; } = null!;

    public bool IsDeleted { get; set; }

    public string HotelStatus { get; set; } = null!;

    public DateTime HotelTimeStart { get; set; }

    public DateTime HotelTimeEnd { get; set; }

    public int? CategoryId { get; set; }

    public int AccountId { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Category? Category { get; set; }

    public virtual ICollection<HotelQuestion> HotelQuestions { get; set; } = new List<HotelQuestion>();

    public virtual ICollection<ImageHotel> ImageHotels { get; set; } = new List<ImageHotel>();

    public virtual ICollection<Room> Rooms { get; set; } = new List<Room>();
}
