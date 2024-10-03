using System;
using System.Collections.Generic;

namespace TripEnjoy.Domain.Models;

public partial class HotelQuestion
{
    public int QuestionId { get; set; }

    public string QuestionContent { get; set; } = null!;

    public string QuestionAnswer { get; set; } = null!;

    public int HotelId { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;
}
