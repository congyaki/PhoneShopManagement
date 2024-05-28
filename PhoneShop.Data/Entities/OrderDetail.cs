using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PhoneShop.Data.Entities;

public partial class OrderDetail
{
    [DisplayName("ID Sản Phẩm")]
    public int PId { get; set; }
    [DisplayName("ID Đơn Hàng")]
    public int OId { get; set; }

    [DisplayName("Số lượng")]
    public int ODQuantity { get; set; }

    [DisplayName("Tổng Giá")]
    public decimal ODPrice { get; set; }
    public Order? Order { get; set; }
    public Product? Product { get; set; }
}
