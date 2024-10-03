using System;
using System.Collections.Generic;

namespace TripEnjoy.Domain.Models;

public partial class VoucherUser
{
    public int VoucherId { get; set; }

    public int AccountId { get; set; }

    public string VoucherStatus { get; set; } = null!;

    public virtual Account Account { get; set; } = null!;

    public virtual Voucher Voucher { get; set; } = null!;
}
