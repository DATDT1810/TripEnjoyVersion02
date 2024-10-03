using System;
using System.Collections.Generic;

namespace TripEnjoy.Domain.Models;

public partial class Conversation
{
    public int ConversationId { get; set; }

    public int AccountId1 { get; set; }

    public int AccountId2 { get; set; }

    public DateTime ConversationCreatedDate { get; set; }

    public virtual Account AccountId1Navigation { get; set; } = null!;

    public virtual Account AccountId2Navigation { get; set; } = null!;

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
}
