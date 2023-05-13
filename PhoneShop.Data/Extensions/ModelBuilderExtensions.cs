using Microsoft.EntityFrameworkCore;
using PhoneShop.Data.Entities;
using PhoneShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PhoneShop.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacturer>().HasData(
                new Manufacturer { MId = 1, MName = "SamSung", MAddress = "129 Samsung-ro, Yeongtong-gu, Suwon-si, Gyeonggi-do, Korea", MEmail = "support@Samsung.com", MPhone = "+82-31-279-9577" },
                new Manufacturer { MId = 2, MName = "Apple", MAddress = "1 Apple Park Way, Cupertino, CA 95014, USA", MEmail = "info@apple.com", MPhone = "+1 (408) 996-1010" },
                new Manufacturer { MId = 3, MName = "OnePlus", MAddress = "Bantian, Longgang District, Shenzhen, China", MEmail = "support@oneplus.com", MPhone = "+86-755-28780808" },
                new Manufacturer { MId = 4, MName = "Xiaomi", MAddress = "Building 3, Wangjing Park, Chaoyang District, Beijing, China", MEmail = "service.global@xiaomi.com", MPhone = "+86-400-100-5678" },
                new Manufacturer { MId = 5, MName = "OPPO", MAddress = "1600 Amphitheatre Parkway, Mountain View, California 94043, United States of America", MEmail = "support@google.com", MPhone = "+1 650-253-0000" }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category { CId = 1, CName = "Flagship", CSortOrder = 1, CParentId = null, CStatus = Status.Active },
                new Category { CId = 2, CName = "Mid-range", CSortOrder = 2, CParentId = null, CStatus = Status.Active },
                new Category { CId = 3, CName = "Apple iPhone Pro series", CSortOrder = 1, CParentId = 1, CStatus = Status.Active },
                new Category { CId = 4, CName = "Samsung Galaxy S series", CSortOrder = 2, CParentId = 1, CStatus = Status.Active },
                new Category { CId = 5, CName = "Samsung Galaxy A series", CSortOrder = 3, CParentId = 2, CStatus = Status.Active }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product { PId = 1, PName = "Samsung Galaxy S21 Ultra", MId = 1, PDescription = "Flagship phone from Samsung", PColor = "Phantom Black", PStorage = "256 GB", PRam = "12 GB", PScreenSize = "6.8 inches", PResolution = "3200 x 1440 pixels", POperatingSystem = "Android 11", PCamera = "Quad camera: 108 MP + 10 MP + 10 MP + 12 MP", PBatteryCapacity = "5000 mAh", PConnectivity = "5G", PWeight = "227 g", PDimension = "165.1 x 75.6 x 8.9 mm", PPrice = 1199, POriginalPrice = 1399, PStock = 50 },
                new Product { PId = 2, PName = "iPhone 13 Pro", MId = 2, PDescription = "Flagship phone from Apple", PColor = "Graphite", PStorage = "128 GB", PRam = "6 GB", PScreenSize = "6.1 inches", PResolution = "2532 x 1170 pixels", POperatingSystem = "iOS 15", PCamera = "Triple camera: 12 MP + 12 MP + 12 MP", PBatteryCapacity = "3095 mAh", PConnectivity = "5G", PWeight = "204 g", PDimension = "146.7 x 71.5 x 7.7 mm", PPrice = 999, POriginalPrice = 1099, PStock = 30 },
                new Product { PId = 3, PName = "OnePlus Nord 2", MId = 3, PDescription = "Mid-range phone from OnePlus", PColor = "Gray Sierra", PStorage = "128 GB", PRam = "8 GB", PScreenSize = "6.43 inches", PResolution = "2400 x 1080 pixels", POperatingSystem = "Android 11", PCamera = "Triple camera: 50 MP + 8 MP + 2 MP", PBatteryCapacity = "4500 mAh", PConnectivity = "5G", PWeight = "189 g", PDimension = "158.9 x 73.2 x 8.3 mm", PPrice = 399, POriginalPrice = 429, PStock = 100 },
                new Product { PId = 4, PName = "Xiaomi Redmi Note 11 Pro", MId = 4, PDescription = "Mid-range phone from Xiaomi", PColor = "Onyx Gray", PStorage = "64 GB", PRam = "6 GB", PScreenSize = "6.67 inches", PResolution = "2400 x 1080 pixels", POperatingSystem = "Android 11", PCamera = "Quad camera: 64 MP + 8 MP + 2 MP + 2 MP", PBatteryCapacity = "5000 mAh", PConnectivity = "4G", PWeight = "193 g", PDimension = "164.1 x 76.9 x 8.5 mm", PPrice = 299, POriginalPrice = 349, PStock = 150 },
                new Product { PId = 5, PName = "OPPO A54", MId = 5, PDescription = "Budget phone from OPPO", PColor = "Crystal Black", PStorage = "128 GB", PRam = "4 GB", PScreenSize = "6.51 inches", PResolution = "1600 x 720 pixels", POperatingSystem = "Android 10", PCamera = "Triple camera: 13 MP + 2 MP + 2 MP", PBatteryCapacity = "5000 mAh", PConnectivity = "4G", PWeight = "192 g", PDimension = "163.6 x 75.7 x 8.4 mm", PPrice = 199, POriginalPrice = 249, PStock = 200 }
                );
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory { PId = 1, CId = 1 },
                new ProductInCategory { PId = 2, CId = 1 },
                new ProductInCategory { PId = 3, CId = 2 },
                new ProductInCategory { PId = 4, CId = 2 },
                new ProductInCategory { PId = 5, CId = 3 }
                );
        }
    }
}
