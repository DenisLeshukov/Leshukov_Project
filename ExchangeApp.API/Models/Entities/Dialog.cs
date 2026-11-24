using System;
using System.Collections.Generic;

namespace ExchangeApp.API.Models.Entities;

public partial class Dialog
{
    public int DialogId { get; set; }

    public int AdvertId { get; set; }

    public int InterestedUserId { get; set; }

    public DateOnly CreatedAt { get; set; }

    public virtual Advert Advert { get; set; } = null!;

    public virtual User InterestedUser { get; set; } = null!;

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
}
