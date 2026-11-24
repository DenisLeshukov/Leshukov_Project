using System;
using System.Collections.Generic;

namespace ExchangeApp.API.Models.Entities;

public partial class Advert
{
    public int AdvertId { get; set; }

    public int UserId { get; set; }

    public int CategoryId { get; set; }

    public int StatusId { get; set; }

    public string Title { get; set; } = null!;

    public string DesiredItem { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Condition { get; set; } = null!;

    public DateOnly CreatedAt { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Dialog> Dialogs { get; set; } = new List<Dialog>();

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();

    public virtual ICollection<Photo> Photos { get; set; } = new List<Photo>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual Statusadvert Status { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
