using System;
using System.Collections.Generic;

namespace TripEnjoy.Domain.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public string AccountUsername { get; set; } = null!;

    public string AccountPassword { get; set; } = null!;

    public int AccountRole { get; set; }

    public bool AccountIsDeleted { get; set; }

    public decimal AccountBalance { get; set; }

    public bool AccountUpLevel { get; set; }

    public string AccountFullname { get; set; } = null!;

    public string AccountPhone { get; set; } = null!;

    public string AccountEmail { get; set; } = null!;

    public string AccountAddress { get; set; } = null!;

    public string AccountGender { get; set; } = null!;

    public DateTime AccountDateOfBirth { get; set; }

    public string AccountImage { get; set; } = null!;

    public string UserId { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Conversation> ConversationAccountId1Navigations { get; set; } = new List<Conversation>();

    public virtual ICollection<Conversation> ConversationAccountId2Navigations { get; set; } = new List<Conversation>();

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Rate> Rates { get; set; } = new List<Rate>();

    public virtual AspNetUser User { get; set; } = null!;

    public virtual ICollection<VoucherUser> VoucherUsers { get; set; } = new List<VoucherUser>();
}
