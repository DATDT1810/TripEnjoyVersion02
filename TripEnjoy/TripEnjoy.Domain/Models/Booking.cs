using System;
using System.Collections.Generic;

namespace TripEnjoy.Domain.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public int AccountId { get; set; }

    public DateTime CheckinDate { get; set; }

    public DateTime CheckoutDate { get; set; }

    public string BookingStatus { get; set; } = null!;

    public int RoomId { get; set; }

    public int VoucherId { get; set; }

    public decimal BookingTotalPrice { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Room Room { get; set; } = null!;

    public virtual Voucher Voucher { get; set; } = null!;
}
