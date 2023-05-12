using System;
using System.Collections.Generic;

namespace PhoneShop.Data.Entities;

public partial class Product
{
    public int PId { get; set; }

    public string PName { get; set; } = null!;
    public int MId { get; set; }

    public string PDescription { get; set; } = null!;

    public string PColor { get; set; } = null!;

    public string PStorage { get; set; } = null!;

    public string PRam { get; set; } = null!;

    public string PScreenSize { get; set; } = null!;

    public string PResolution { get; set; } = null!;

    public string POperatingSystem { get; set; } = null!;

    public string PCamera { get; set; } = null!;

    public string PBatteryCapacity { get; set; } = null!;

    public string PConnectivity { get; set; } = null!;

    public string PWeight { get; set; } = null!;

    public string PDimension { get; set; } = null!;

    public decimal PPrice { get; set; }
    public decimal POriginalPrice { get; set; }
    public int PStock { get; set; }

    public List<ProductInCategory> ProductInCategories { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }
    public Manufacturer Manufacturer { get; set; }
}
