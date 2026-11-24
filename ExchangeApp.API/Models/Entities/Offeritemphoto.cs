using System;
using System.Collections.Generic;

namespace ExchangeApp.API.Models.Entities;

public partial class Offeritemphoto
{
    public int PhotoId { get; set; }

    public int OfferitemId { get; set; }

    public string PhotoUrl { get; set; } = null!;

    public virtual Offeritem Offeritem { get; set; } = null!;
}
