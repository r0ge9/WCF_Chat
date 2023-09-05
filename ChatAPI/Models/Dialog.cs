using System;
using System.Collections.Generic;

namespace ChatAPI.Models;

public partial class Dialog
{
    public int Id { get; set; }

    public int? FirstUserId { get; set; }

    public int? SecondUserId { get; set; }

    public virtual User? FirstUser { get; set; }

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    public virtual User? SecondUser { get; set; }
}
