using System;
using System.Collections.Generic;

namespace ChatAPI.Models;

public partial class Message
{
    public int Id { get; set; }

    public string Text { get; set; } = null!;

    public int? DialogId { get; set; }

    public int? UserId { get; set; }

    public int? ToUserId { get; set; }

    public string Ip { get; set; } = null!;

    public bool IsRead { get; set; }

    public bool? IsVisibleFirstUser { get; set; }

    public bool? IsVisibleSecondUser { get; set; }

    public DateTime SendDateTime { get; set; }

    public virtual Dialog? Dialog { get; set; }

    public virtual User? ToUser { get; set; }

    public virtual User? User { get; set; }
}
