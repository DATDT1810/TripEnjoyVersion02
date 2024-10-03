using System;
using System.Collections.Generic;

namespace TripEnjoy.Domain.Models;

public partial class Voucher
{
    public int VoucherId { get; set; }

    public string VoucherName { get; set; } = null!;

    public string VoucherCode { get; set; } = null!;

    public int VoucherDiscount { get; set; }

    public DateTime VoucherStartDate { get; set; }

    public DateTime VoucherEndDate { get; set; }

    public int VoucherQuantity { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<VoucherUser> VoucherUsers { get; set; } = new List<VoucherUser>();
}
