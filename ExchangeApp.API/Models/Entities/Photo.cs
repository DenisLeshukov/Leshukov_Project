using System;
using System.Collections.Generic;

namespace ExchangeApp.API.Models.Entities;

public partial class Photo
{
    public int PhotoId { get; set; }

    public int AdvertId { get; set; }

    public string PhotoUrl { get; set; } = null!;

    public virtual Advert Advert { get; set; } = null!;
}
