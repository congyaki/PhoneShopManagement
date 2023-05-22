using PhoneShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PhoneShop.Data.Entities;

public partial class Order
{
    public int OId { get; set; }

    public int CusId { get; set; }

    [DisplayName("Ngày mua")]
    public DateTime ODate { get; set; }

    [DisplayName("Tình trạng")]
    public OrderStatus OStatus { get; set; }

    public List<OrderDetail>? OrderDetails { get; set; }
    public Customer? Customer { get; set; }
}
