using System;
using System.Collections.Generic;

namespace PhoneShop.Data.Entities;

public partial class Manufacturer
{
    public int MId { get; set; }

    public string MName { get; set; } = null!;

    public string MAddress { get; set; } = null!;

    public string MEmail { get; set; } = null!;

    public string MPhone { get; set; } = null!;

    public List<Product> Products { get; set; }
}
