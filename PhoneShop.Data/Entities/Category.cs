using PhoneShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PhoneShop.Data.Entities;

public partial class Category
{
    [DisplayName("ID")]
    public int CId { get; set; }

    [DisplayName("Tên")]
    public string CName { get; set; }

    [DisplayName("Thứ tự sắp xếp")]
    public int CSortOrder { get; set; }

    [DisplayName("Thể loại cha")]
    public int? CParentId { get; set; }

    public List<ProductInCategory>? ProductInCategories { get; set; }
}
