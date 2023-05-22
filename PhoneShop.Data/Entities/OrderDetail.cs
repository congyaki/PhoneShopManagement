using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PhoneShop.Data.Entities;

public partial class OrderDetail
{
    public int PId { get; set; }

    public int OId { get; set; }

    [DisplayName("Số lượng")]
    public int ODQuantity { get; set; }

    [DisplayName("Giá")]
    public decimal ODPrice { get; set; }
    public Order Order { get; set; }
    public Product Product { get; set; }
}
