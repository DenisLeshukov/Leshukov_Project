using System;
using System.Collections.Generic;

namespace ExchangeApp.API.Models.Entities;

public partial class Offeritem
{
    public int OfferItemId { get; set; }

    public int OfferId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Condition { get; set; } = null!;

    public virtual Offer Offer { get; set; } = null!;

    public virtual ICollection<Offeritemphoto> Offeritemphotos { get; set; } = new List<Offeritemphoto>();
}
