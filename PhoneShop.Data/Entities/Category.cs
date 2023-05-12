using PhoneShop.Data.Enum;
using System;
using System.Collections.Generic;

namespace PhoneShop.Data.Entities;

public partial class Category
{
    public int CId { get; set; }

    public string CName { get; set; } = null!;
    public int CSortOrder { get; set; }
    public int? CParentId { get; set; }
    public Status CStatus { get; set; }

    public List<ProductInCategory> ProductInCategories { get; set; }
}
