using System;
using System.Collections.Generic;

namespace TripEnjoy.Domain.Models;

public partial class ImageHotel
{
    public int ImageId { get; set; }

    public string ImageUrl { get; set; } = null!;

    public int HotelId { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;
}
