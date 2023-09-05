using System;
using System.Collections.Generic;

namespace ChatAPI.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Username { get; set; } = null!;

    public byte[]? Image { get; set; }

    public string Email { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsOnline { get; set; }

    public DateTime? LastTimeOnline { get; set; }

    public virtual ICollection<Dialog> DialogFirstUsers { get; set; } = new List<Dialog>();

    public virtual ICollection<Dialog> DialogSecondUsers { get; set; } = new List<Dialog>();

    public virtual ICollection<Message> MessageToUsers { get; set; } = new List<Message>();

    public virtual ICollection<Message> MessageUsers { get; set; } = new List<Message>();
}
