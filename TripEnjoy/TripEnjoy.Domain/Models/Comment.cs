using System;
using System.Collections.Generic;

namespace TripEnjoy.Domain.Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public int AccountId { get; set; }

    public int RoomId { get; set; }

    public string CommentContent { get; set; } = null!;

    public int CommentLevel { get; set; }

    public string CommentReply { get; set; } = null!;

    public DateTime CommentDate { get; set; }

    public virtual Account Account { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;
}
