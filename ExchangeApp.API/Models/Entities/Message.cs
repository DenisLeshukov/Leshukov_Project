using System;
using System.Collections.Generic;

namespace ExchangeApp.API.Models.Entities;

public partial class Message
{
    public int MessageId { get; set; }

    public int DialogId { get; set; }

    public int SenderId { get; set; }

    public string TextMessage { get; set; } = null!;

    public DateOnly? SentAt { get; set; }

    public virtual Dialog Dialog { get; set; } = null!;

    public virtual User Sender { get; set; } = null!;
}
