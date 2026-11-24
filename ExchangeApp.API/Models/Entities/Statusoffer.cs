using System;
using System.Collections.Generic;

namespace ExchangeApp.API.Models.Entities;

public partial class Statusoffer
{
    public int StatusOfferId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();
}
