using System;
using System.Collections.Generic;

namespace ExchangeApp.API.Models.Entities;

public partial class Offer
{
    public int OfferId { get; set; }

    public int AdvertId { get; set; }

    public int UserId { get; set; }

    public int StatusId { get; set; }

    public DateOnly CreatedAt { get; set; }

    public virtual Advert Advert { get; set; } = null!;

    public virtual ICollection<Offeritem> Offeritems { get; set; } = new List<Offeritem>();

    public virtual Statusoffer Status { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
