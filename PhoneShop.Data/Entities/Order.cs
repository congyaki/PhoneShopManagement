using PhoneShop.Data.Enums;
using System;
using System.Collections.Generic;

namespace PhoneShop.Data.Entities;

public partial class Order
{
    public int OId { get; set; }

    public DateTime ODate { get; set; }
    public Guid UserId { get; set; }
    public OrderStatus OStatus { get; set; }

    public List<OrderDetail> OrderDetails { get; set; }
}
