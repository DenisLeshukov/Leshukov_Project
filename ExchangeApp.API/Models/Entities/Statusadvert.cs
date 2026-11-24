using System;
using System.Collections.Generic;

namespace ExchangeApp.API.Models.Entities;

public partial class Statusadvert
{
    public int StatusAdvertId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Advert> Adverts { get; set; } = new List<Advert>();
}
