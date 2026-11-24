using System;
using System.Collections.Generic;

namespace ExchangeApp.API.Models.Entities;

public partial class Attribute
{
    public int AttributeId { get; set; }

    public string Name { get; set; } = null!;
}
