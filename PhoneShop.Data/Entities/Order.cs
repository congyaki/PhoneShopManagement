using PhoneShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PhoneShop.Data.Entities;

public partial class Order
{
    [DisplayName("Order ID")]
    public int OId { get; set; }


    [DisplayName("Customer ID")]
    public int CusId { get; set; }
    [DisplayName("Date of Purchase")]
    public DateTime ODate { get; set; }

    [DisplayName("Status")]
    public OrderStatus OStatus { get; set; }

    public List<OrderDetail>? OrderDetails { get; set; }
    public Customer? Customer { get; set; }
}
