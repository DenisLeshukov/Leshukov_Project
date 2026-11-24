using System;
using System.Collections.Generic;

namespace ExchangeApp.API.Models.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public int? Rate { get; set; }

    public DateOnly RegistrationDate { get; set; }

    public string PhotoUrl { get; set; } = null!;

    public virtual ICollection<Advert> Adverts { get; set; } = new List<Advert>();

    public virtual ICollection<Dialog> Dialogs { get; set; } = new List<Dialog>();

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
