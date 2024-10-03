using System;
using System.Collections.Generic;

namespace TripEnjoy.Domain.Models;

public partial class Notification
{
    public int NotificationId { get; set; }

    public string NotificationContent { get; set; } = null!;

    public DateTime NotificationDate { get; set; }

    public int AccountId { get; set; }

    public virtual Account Account { get; set; } = null!;
}
