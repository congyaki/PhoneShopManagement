using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PhoneShop.Data.Entities;

public partial class Manufacturer
{
    [DisplayName("ID")]
    public int MId { get; set; }

    [DisplayName("Tên")]
    public string MName { get; set; }

    [DisplayName("Địa chỉ")]
    public string MAddress { get; set; }

    [DisplayName("Email")]
    public string MEmail { get; set; }

    [DisplayName("Số điện thoại")]
    public string MPhone { get; set; } 

    public List<Product>? Products { get; set; }
}
