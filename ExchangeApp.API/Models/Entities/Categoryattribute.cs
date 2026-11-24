using System;
using System.Collections.Generic;

namespace ExchangeApp.API.Models.Entities;

public partial class Categoryattribute
{
    public int CategoryId { get; set; }

    public int AttributeId { get; set; }

    public virtual Attribute Attribute { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;
}
