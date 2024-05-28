using PhoneShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PhoneShop.Data.Entities;

public partial class Order
{
    [DisplayName("ID")]
    public int OId { get; set; }


    [DisplayName("ID Khách Hàng")]
    public int CusId { get; set; }
    [DisplayName("Ngày Mua")]
    public DateTime ODate { get; set; }

    [DisplayName("Cách Thức Mua")]
    public OrderStatus OStatus { get; set; }

    public List<OrderDetail>? OrderDetails { get; set; }
    public Customer? Customer { get; set; }
}
