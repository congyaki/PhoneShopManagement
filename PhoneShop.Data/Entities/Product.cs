using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PhoneShop.Data.Entities;

public class Product
{
    [DisplayName("ID")]
    public int PId { get; set; }

    [DisplayName("Tên")]
    public string PName { get; set; }

    [DisplayName("Nhà Sản Xuất")]
    public int MId { get; set; }

    [DisplayName("Mô tả")]
    public string PDescription { get; set; }

    [DisplayName("Màu")]
    public string PColor { get; set; }

    [DisplayName("Bộ lưu trữ")]
    public string PStorage { get; set; }

        [DisplayName("Ram")]
    public string PRam { get; set; }

        [DisplayName("Kích thước màn hình")]
    public string PScreenSize { get; set; }

        [DisplayName("Độ phân giải")]
    public string PResolution { get; set; }

        [DisplayName("Hệ điều hành")]
    public string POperatingSystem { get; set; }

        [DisplayName("Camera")]
    public string PCamera { get; set; }

        [DisplayName("Dung lượng Pin")]
    public string PBatteryCapacity { get; set; }

       [DisplayName("khả năng kết nối")]
    public string PConnectivity { get; set; }

        [DisplayName("trọng lượng")]
    public string PWeight { get; set; }

        [DisplayName("kích thước")]
    public string PDimension { get; set; }

       [DisplayName("Giá bán")]
    public decimal PPrice { get; set; }

       [DisplayName("Giá gốc")]
    public decimal POriginalPrice { get; set; }

       [DisplayName("Số lượng tồn kho")]
    public int PStock { get; set; }


    public List<ProductImage>? ProductImages { get; set; }
    public List<ProductInCategory>? ProductInCategories { get; set; }
    public List<OrderDetail>? OrderDetails { get; set; }

    [DisplayName("Nhà sản xuất")]
    public Manufacturer? Manufacturer { get; set; }
}
