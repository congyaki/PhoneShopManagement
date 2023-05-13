using System;
using System.Collections.Generic;

namespace PhoneShop.Data.Entities;

public partial class Product
{
    public int PId { get; set; }

    public string PName { get; set; } 
    public int MId { get; set; }

    public string PDescription { get; set; } 

    public string PColor { get; set; } 

    public string PStorage { get; set; } 

    public string PRam { get; set; } 

    public string PScreenSize { get; set; } 

    public string PResolution { get; set; } 

    public string POperatingSystem { get; set; } 

    public string PCamera { get; set; } 

    public string PBatteryCapacity { get; set; } 

    public string PConnectivity { get; set; } 

    public string PWeight { get; set; } 

    public string PDimension { get; set; } 

    public decimal PPrice { get; set; }
    public decimal POriginalPrice { get; set; }
    public int PStock { get; set; }

    public List<ProductInCategory> ProductInCategories { get; set; }
    public List<OrderDetail> OrderDetails { get; set; }
    public Manufacturer Manufacturer { get; set; }
}
