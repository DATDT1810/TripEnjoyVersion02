using System;
using System.Collections.Generic;

namespace TripEnjoy.Domain.Models;

public partial class Message
{
    public int MessageId { get; set; }

    public int ConversationId { get; set; }

    public int SenderId { get; set; }

    public string MessageContent { get; set; } = null!;

    public DateTime MessageDate { get; set; }

    public bool MessageStatus { get; set; }

    public virtual Conversation Conversation { get; set; } = null!;

    public virtual Account Sender { get; set; } = null!;
}
