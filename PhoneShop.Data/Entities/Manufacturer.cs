using System;
using System.Collections.Generic;

namespace PhoneShop.Data.Entities;

public partial class Manufacturer
{
    public int MId { get; set; }

    public string MName { get; set; }

    public string MAddress { get; set; } 

    public string MEmail { get; set; } 

    public string MPhone { get; set; } 

    public List<Product> Products { get; set; }
}
