using System;
using System.Collections.Generic;

namespace ExchangeApp.API.Models.Entities;

public partial class Review
{
    public int ReviewId { get; set; }

    public int UserId { get; set; }

    public int AdvertId { get; set; }

    public int Rate { get; set; }

    public string Description { get; set; } = null!;

    public virtual Advert Advert { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
