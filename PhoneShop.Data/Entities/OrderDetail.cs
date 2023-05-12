using System;
using System.Collections.Generic;

namespace PhoneShop.Data.Entities;

public partial class OrderDetail
{
    public int PId { get; set; }

    public int OId { get; set; }

    public int ODQuantity { get; set; }
    public decimal ODPrice { get; set; }
    public Order Order { get; set; }
    public Product Product { get; set; }
}
