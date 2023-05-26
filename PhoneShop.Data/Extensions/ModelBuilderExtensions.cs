using Microsoft.AspNetCore.Identity;
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
                new Manufacturer { MId = 5, MName = "OPPO", MAddress = "1600 Amphitheatre Parkway, Mountain View, California 94043, United States of America", MEmail = "support@google.com", MPhone = "+1 650-253-0000" },
                new Manufacturer { MId = 6, MName = "Huawei", MAddress = "Bantian, Longgang District, Shenzhen, China", MEmail = "support@huawei.com", MPhone = "+86-755-28780808" },
                new Manufacturer { MId = 7, MName = "Sony", MAddress = "1-7-1 Konan, Minato-ku, Tokyo 108-0075, Japan", MEmail = "support@sony.com", MPhone = "+81-3-6748-2111" },
                new Manufacturer { MId = 8, MName = "LG", MAddress = "128 Yeoui-daero, Yeongdeungpo-gu, Seoul, 07336, South Korea", MEmail = "support@lg.com", MPhone = "+82-2-3777-1114" },
                new Manufacturer { MId = 9, MName = "Nokia", MAddress = "Karaportti 3, 02610 Espoo, Finland", MEmail = "support@nokia.com", MPhone = "+358 (0) 10 44 88 000" },
                new Manufacturer { MId = 10, MName = "Motorola", MAddress = "222 W Merchandise Mart Plaza #1800, Chicago, IL 60654, USA", MEmail = "support@motorola.com", MPhone = "+1 (800) 668-6765" },
                new Manufacturer { MId = 11, MName = "Asus", MAddress = "No. 15 Li-De Rd., Beitou District, Taipei 112, Taiwan", MEmail = "support@asus.com", MPhone = "+886-2-2894-3447" },
                new Manufacturer { MId = 12, MName = "Lenovo", MAddress = "Morrisville, NC 27560, United States", MEmail = "support@lenovo.com", MPhone = "+1-800-426-7378" },
                new Manufacturer { MId = 13, MName = "Google", MAddress = "1600 Amphitheatre Parkway, Mountain View, California 94043, United States of America", MEmail = "support@google.com", MPhone = "+1 650-253-0000" },
                new Manufacturer { MId = 14, MName = "Vivo", MAddress = "No. 1 Building, Shangdi Xinxi Road, Haidian District, Beijing, China", MEmail = "support@vivo.com", MPhone = "+86-755-28780808" }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category { CId = 1, CName = "Flagship", CSortOrder = 1, CParentId = null},
                new Category { CId = 2, CName = "Mid-range", CSortOrder = 2, CParentId = null},
                new Category { CId = 3, CName = "Apple iPhone Pro series", CSortOrder = 1, CParentId = 1},
                new Category { CId = 4, CName = "Samsung Galaxy S series", CSortOrder = 2, CParentId = 1 },
                new Category { CId = 5, CName = "Samsung Galaxy A series", CSortOrder = 3, CParentId = 2 },
                new Category { CId = 6, CName = "OnePlus 9 series", CSortOrder = 1, CParentId = 1 },
                new Category { CId = 7, CName = "Xiaomi Mi series", CSortOrder = 2, CParentId = 1 },
                new Category { CId = 8, CName = "OPPO Reno series", CSortOrder = 3, CParentId = 1 },
                new Category { CId = 9, CName = "Huawei P series", CSortOrder = 4, CParentId = 1 },
                new Category { CId = 10, CName = "LG G series", CSortOrder = 5, CParentId = 1 },
                new Category { CId = 11, CName = "Samsung Galaxy Note series", CSortOrder = 1, CParentId = 4 },
                new Category { CId = 12, CName = "Samsung Galaxy Fold series", CSortOrder = 2, CParentId = 4 },
                new Category { CId = 13, CName = "Samsung Galaxy Z series", CSortOrder = 3, CParentId = 4 },
                new Category { CId = 14, CName = "Xiaomi Redmi series", CSortOrder = 1, CParentId = 2 },
                new Category { CId = 15, CName = "Realme series", CSortOrder = 2, CParentId = 2 },
                new Category { CId = 16, CName = "Nokia X series", CSortOrder = 3, CParentId = 2 }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product { PId = 1, PName = "Samsung Galaxy S21 Ultra", MId = 1, PDescription = "Flagship phone from Samsung", PColor = "Phantom Black", PStorage = "256 GB", PRam = "12 GB", PScreenSize = "6.8 inches", PResolution = "3200 x 1440 pixels", POperatingSystem = "Android 11", PCamera = "Quad camera: 108 MP + 10 MP + 10 MP + 12 MP", PBatteryCapacity = "5000 mAh", PConnectivity = "5G", PWeight = "227 g", PDimension = "165.1 x 75.6 x 8.9 mm", PPrice = 1199, POriginalPrice = 1399, PStock = 50, PAvatar = "1.jpg" },
                new Product { PId = 2, PName = "iPhone 13 Pro", MId = 2, PDescription = "Flagship phone from Apple", PColor = "Graphite", PStorage = "128 GB", PRam = "6 GB", PScreenSize = "6.1 inches", PResolution = "2532 x 1170 pixels", POperatingSystem = "iOS 15", PCamera = "Triple camera: 12 MP + 12 MP + 12 MP", PBatteryCapacity = "3095 mAh", PConnectivity = "5G", PWeight = "204 g", PDimension = "146.7 x 71.5 x 7.7 mm", PPrice = 999, POriginalPrice = 1099, PStock = 30, PAvatar = "2.jpg" },
                new Product { PId = 3, PName = "OnePlus Nord 2", MId = 3, PDescription = "Mid-range phone from OnePlus", PColor = "Gray Sierra", PStorage = "128 GB", PRam = "8 GB", PScreenSize = "6.43 inches", PResolution = "2400 x 1080 pixels", POperatingSystem = "Android 11", PCamera = "Triple camera: 50 MP + 8 MP + 2 MP", PBatteryCapacity = "4500 mAh", PConnectivity = "5G", PWeight = "189 g", PDimension = "158.9 x 73.2 x 8.3 mm", PPrice = 399, POriginalPrice = 429, PStock = 100, PAvatar = "3.jpg" },
                new Product { PId = 4, PName = "Xiaomi Redmi Note 11 Pro", MId = 4, PDescription = "Mid-range phone from Xiaomi", PColor = "Onyx Gray", PStorage = "64 GB", PRam = "6 GB", PScreenSize = "6.67 inches", PResolution = "2400 x 1080 pixels", POperatingSystem = "Android 11", PCamera = "Quad camera: 64 MP + 8 MP + 2 MP + 2 MP", PBatteryCapacity = "5000 mAh", PConnectivity = "4G", PWeight = "193 g", PDimension = "164.1 x 76.9 x 8.5 mm", PPrice = 299, POriginalPrice = 349, PStock = 150, PAvatar = "4.jpg" },
                new Product { PId = 5, PName = "OPPO A54", MId = 5, PDescription = "Budget phone from OPPO", PColor = "Crystal Black", PStorage = "128 GB", PRam = "4 GB", PScreenSize = "6.51 inches", PResolution = "1600 x 720 pixels", POperatingSystem = "Android 10", PCamera = "Triple camera: 13 MP + 2 MP + 2 MP", PBatteryCapacity = "5000 mAh", PConnectivity = "4G", PWeight = "192 g", PDimension = "163.6 x 75.7 x 8.4 mm", PPrice = 199, POriginalPrice = 249, PStock = 200, PAvatar = "5.jpg" },
                new Product { PId = 6, PName = "Huawei Mate 50 Pro", MId = 6, PDescription = "Flagship phone from Huawei", PColor = "Mystic Silver", PStorage = "256 GB", PRam = "12 GB", PScreenSize = "6.76 inches", PResolution = "2772 x 1344 pixels", POperatingSystem = "Android 12", PCamera = "Quad camera: 50 MP + 64 MP + 13 MP + 40 MP", PBatteryCapacity = "4400 mAh", PConnectivity = "5G", PWeight = "212 g", PDimension = "163.8 x 75.8 x 8.6 mm", PPrice = 1299, POriginalPrice = 1499, PStock = 50, PAvatar = "6.jpg" },
                new Product { PId = 7, PName = "Sony Xperia 1 III", MId = 7, PDescription = "Flagship phone from Sony", PColor = "Frosted Black", PStorage = "256 GB", PRam = "12 GB", PScreenSize = "6.5 inches", PResolution = "3840 x 1644 pixels", POperatingSystem = "Android 11", PCamera = "Triple camera: 12 MP + 12 MP + 12 MP", PBatteryCapacity = "4500 mAh", PConnectivity = "5G", PWeight = "186 g", PDimension = "165.0 x 71.0 x 8.2 mm", PPrice = 1299, POriginalPrice = 1399, PStock = 30, PAvatar = "7.jpg" },
                new Product { PId = 8, PName = "LG Velvet 5G", MId = 8, PDescription = "Mid-range phone from LG", PColor = "Illusion Sunset", PStorage = "128 GB", PRam = "6 GB", PScreenSize = "6.8 inches", PResolution = "2460 x 1080 pixels", POperatingSystem = "Android 10", PCamera = "Triple camera: 48 MP + 8 MP + 5 MP", PBatteryCapacity = "4300 mAh", PConnectivity = "5G", PWeight = "180 g", PDimension = "167.2 x 74.1 x 7.9 mm", PPrice = 499, POriginalPrice = 599, PStock = 100, PAvatar = "8.jpg" },
                new Product { PId = 9, PName = "Nokia X20", MId = 9, PDescription = "Mid-range phone from Nokia", PColor = "Midnight Sun", PStorage = "128 GB", PRam = "8 GB", PScreenSize = "6.67 inches", PResolution = "2400 x 1080 pixels", POperatingSystem = "Android 11", PCamera = "Quad camera: 64 MP + 5 MP + 2 MP + 2 MP", PBatteryCapacity = "4470 mAh", PConnectivity = "5G", PWeight = "220 g", PDimension = "168.9 x 79.7 x 9.1 mm", PPrice = 449, POriginalPrice = 499, PStock = 150, PAvatar = "9.jpg" },
                new Product { PId = 10, PName = "Motorola Moto G Power (2022)", MId = 10, PDescription = "Budget phone from Motorola", PColor = "Flash Gray", PStorage = "64 GB", PRam = "4 GB", PScreenSize = "6.6 inches", PResolution = "1600 x 720 pixels", POperatingSystem = "Android 11", PCamera = "Triple camera: 48 MP + 2 MP + 2 MP", PBatteryCapacity = "5000 mAh", PConnectivity = "4G", PWeight = "206 g", PDimension = "165.3 x 75.9 x 9.5 mm", PPrice = 199, POriginalPrice = 249, PStock = 200, PAvatar = "10.jpg" },
                new Product { PId = 11, PName = "Samsung Galaxy Z Fold 3", MId = 1, PDescription = "Foldable flagship phone from Samsung", PColor = "Phantom Green", PStorage = "512 GB", PRam = "12 GB", PScreenSize = "7.6 inches", PResolution = "2208 x 1768 pixels", POperatingSystem = "Android 11", PCamera = "Triple camera: 12 MP + 12 MP + 12 MP", PBatteryCapacity = "4400 mAh", PConnectivity = "5G", PWeight = "271 g", PDimension = "158.2 x 128.1 x 6.4 mm", PPrice = 1799, POriginalPrice = 1999, PStock = 50, PAvatar = "11.jpg" },
                new Product { PId = 12, PName = "iPhone SE (2022)", MId = 2, PDescription = "Budget phone from Apple", PColor = "Product Red", PStorage = "64 GB", PRam = "4 GB", PScreenSize = "4.7 inches", PResolution = "1334 x 750 pixels", POperatingSystem = "iOS 15", PCamera = "Single camera: 12 MP", PBatteryCapacity = "1821 mAh", PConnectivity = "4G", PWeight = "148 g", PDimension = "138.4 x 67.3 x 7.3 mm", PPrice = 399, POriginalPrice = 449, PStock = 100, PAvatar = "12.jpg" },
                new Product { PId = 13, PName = "Xiaomi Mi 12", MId = 4, PDescription = "Flagship phone from Xiaomi", PColor = "Cosmic Black", PStorage = "256 GB", PRam = "12 GB", PScreenSize = "6.81 inches", PResolution = "3200 x 1440 pixels", POperatingSystem = "Android 12", PCamera = "Quad camera: 108 MP + 50 MP + 12 MP + 20 MP", PBatteryCapacity = "5000 mAh", PConnectivity = "5G", PWeight = "205 g", PDimension = "164.3 x 74.6 x 8.8 mm", PPrice = 1099, POriginalPrice = 1199, PStock = 30, PAvatar = "13.jpg" },
                new Product { PId = 14, PName = "Google Pixel 6 Pro", MId = 11, PDescription = "Flagship phone from Google", PColor = "Stormy Black", PStorage = "256 GB", PRam = "12 GB", PScreenSize = "6.7 inches", PResolution = "3120 x 1440 pixels", POperatingSystem = "Android 12", PCamera = "Triple camera: 50 MP + 48 MP + 12 MP", PBatteryCapacity = "5000 mAh", PConnectivity = "5G", PWeight = "207 g", PDimension = "163.9 x 75.8 x 8.9 mm", PPrice = 1099, POriginalPrice = 1199, PStock = 50, PAvatar = "14.jpg" },
                new Product { PId = 15, PName = "Samsung Galaxy S21 Ultra", MId = 4, PDescription = "Flagship phone from Samsung with the best camera", PColor = "Phantom Black", PStorage = "512 GB", PRam = "16 GB", PScreenSize = "6.8 inches", PResolution = "3200 x 1440 pixels", POperatingSystem = "Android 11", PCamera = "Quad camera: 108 MP + 10 MP + 10 MP + 12 MP", PBatteryCapacity = "5000 mAh", PConnectivity = "5G", PWeight = "229 g", PDimension = "165.1 x 75.6 x 8.9 mm", PPrice = 1599, POriginalPrice = 1799, PStock = 70, PAvatar = "15.jpg" },
                new Product { PId = 16, PName = "Realme GT Neo 2", MId = 13, PDescription = "Mid-range phone from Realme", PColor = "Black", PStorage = "128 GB", PRam = "8 GB", PScreenSize = "6.62 inches", PResolution = "2400 x 1080 pixels", POperatingSystem = "Android 11", PCamera = "Triple camera: 64 MP + 8 MP + 2 MP", PBatteryCapacity = "5000 mAh", PConnectivity = "5G", PWeight = "186 g", PDimension = "158.5 x 73.3 x 8.4 mm", PPrice = 399, POriginalPrice = 449, PStock = 100, PAvatar = "16.jpg" },
                new Product { PId = 17, PName = "ZTE Axon 30 Ultra", MId = 14, PDescription = "Flagship phone from ZTE", PColor = "Black", PStorage = "256 GB", PRam = "12 GB", PScreenSize = "6.67 inches", PResolution = "2400 x 1080 pixels", POperatingSystem = "Android 11", PCamera = "Triple camera: 64 MP + 64 MP + 64 MP", PBatteryCapacity = "4600 mAh", PConnectivity = "5G", PWeight = "188 g", PDimension = "161.5 x 73 x 8 mm", PPrice = 749, POriginalPrice = 799, PStock = 80, PAvatar = "17.jpg" },
                new Product { PId = 18, PName = "OnePlus 10 Pro", MId = 5, PDescription = "Flagship phone from OnePlus", PColor = "Morning Mist", PStorage = "512 GB", PRam = "12 GB", PScreenSize = "6.7 inches", PResolution = "3216 x 1440 pixels", POperatingSystem = "Android 12", PCamera = "Quad camera: 50 MP + 48 MP + 8 MP + 2 MP", PBatteryCapacity = "4500 mAh", PConnectivity = "5G", PWeight = "199 g", PDimension = "165.2 x 74.6 x 8.7 mm", PPrice = 1299, POriginalPrice = 1399, PStock = 60, PAvatar = "18.jpg" },
                new Product { PId = 19, PName = "OPPO Find X5 Pro", MId = 5, PDescription = "Flagship phone from OPPO", PColor = "Galactic Silver", PStorage = "512 GB", PRam = "16 GB", PScreenSize = "6.7 inches", PResolution = "3216 x 1440 pixels", POperatingSystem = "Android 12", PCamera = "Quad camera: 50 MP + 50 MP + 13 MP + 5 MP", PBatteryCapacity = "4500 mAh", PConnectivity = "5G", PWeight = "190 g", PDimension = "163.6 x 74 x 8.26 mm", PPrice = 1499, POriginalPrice = 1599, PStock = 40, PAvatar = "19.jpg" },
                new Product { PId = 20, PName = "Vivo X70 Pro+", MId = 12, PDescription = "Flagship phone from Vivo", PColor = "Orange", PStorage = "512 GB", PRam = "12 GB", PScreenSize = "6.78 inches", PResolution = "3200 x 1440 pixels", POperatingSystem = "Android 11", PCamera = "Quad camera: 50 MP + 48MP + 12 MP + 8 MP", PBatteryCapacity = "4500 mAh", PConnectivity = "5G", PWeight = "209 g", PDimension = "164.8 x 75 x 9 mm", PPrice = 1299, POriginalPrice = 1399, PStock = 30, PAvatar = "20.jpg" },
                new Product { PId = 21, PName = "BlackBerry KEY3", MId = 13, PDescription = "Smartphone with a physical keyboard from BlackBerry", PColor = "Black", PStorage = "128 GB", PRam = "6 GB", PScreenSize = "4.5 inches", PResolution = "1620 x 1080 pixels", POperatingSystem = "Android 11", PCamera = "Dual camera: 12 MP + 12 MP", PBatteryCapacity = "4000 mAh", PConnectivity = "4G", PWeight = "190 g", PDimension = "151.4 x 71.8 x 8.5 mm", PPrice = 699, POriginalPrice = 799, PStock = 20, PAvatar = "21.jpg" },
                new Product { PId = 22, PName = "Honor Magic 3", MId = 6, PDescription = "Flagship phone from Honor", PColor = "Golden Hour", PStorage = "256 GB", PRam = "8 GB", PScreenSize = "6.76 inches", PResolution = "2772 x 1344 pixels", POperatingSystem = "Android 11", PCamera = "Quad camera: 50 MP + 64 MP + 13 MP + 3D ToF", PBatteryCapacity = "4600 mAh", PConnectivity = "5G", PWeight = "203 g", PDimension = "162.8 x 74.9 x 9.5 mm", PPrice = 999, POriginalPrice = 1099, PStock = 50, PAvatar = "22.jpg" },
                new Product { PId = 23, PName = "LG V70 ThinQ", MId = 14, PDescription = "Flagship phone from LG", PColor = "Aurora Black", PStorage = "256 GB", PRam = "8 GB", PScreenSize = "6.8 inches", PResolution = "3200 x 1440 pixels", POperatingSystem = "Android 12", PCamera = "Triple camera: 108 MP + 24 MP + 12 MP", PBatteryCapacity = "5000 mAh", PConnectivity = "5G", PWeight = "189 g", PDimension = "166.4 x 76.1 x 8.8 mm", PPrice = 1199, POriginalPrice = 1299, PStock = 35, PAvatar = "23.jpg" },
                new Product { PId = 24, PName = "Xiaomi Mi Note 11", MId = 7, PDescription = "Mid-range phone from Xiaomi", PColor = "Cosmic Black", PStorage = "128 GB", PRam = "6 GB", PScreenSize = "6.67 inches", PResolution = "2400 x 1080 pixels", POperatingSystem = "Android 11", PCamera = "Triple camera: 108 MP + 8 MP + 5 MP", PBatteryCapacity = "4900 mAh", PConnectivity = "5G", PWeight = "196 g", PDimension = "164.3 x 74.6 x 8.8 mm", PPrice = 599, POriginalPrice = 649, PStock = 90, PAvatar = "24.jpg" },
                new Product { PId = 25, PName = "Motorola Edge 30", MId = 8, PDescription = "Mid-range phone from Motorola", PColor = "Midnight Blue", PStorage = "128 GB", PRam = "6 GB", PScreenSize = "6.7 inches", PResolution = "2400 x 1080 pixels", POperatingSystem = "Android 11", PCamera = "Triple camera: 108MP + 16 MP + 8 MP", PBatteryCapacity = "5000 mAh", PConnectivity = "5G", PWeight = "185 g", PDimension = "163.1 x 76.3 x 8.9 mm", PPrice = 499, POriginalPrice = 549, PStock = 120, PAvatar = "25.jpg" }
                );
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory { PId = 1, CId = 1 },
                new ProductInCategory { PId = 2, CId = 1 },
                new ProductInCategory { PId = 3, CId = 2 },
                new ProductInCategory { PId = 4, CId = 2 },
                new ProductInCategory { PId = 5, CId = 3 },
                new ProductInCategory { PId = 6, CId = 3 },
                new ProductInCategory { PId = 7, CId = 4 },
                new ProductInCategory { PId = 8, CId = 4 },
                new ProductInCategory { PId = 9, CId = 4 },
                new ProductInCategory { PId = 10, CId = 5 },
                new ProductInCategory { PId = 11, CId = 5 },
                new ProductInCategory { PId = 12, CId = 5 },
                new ProductInCategory { PId = 13, CId = 6 },
                new ProductInCategory { PId = 14, CId = 6 },
                new ProductInCategory { PId = 15, CId = 7 },
                new ProductInCategory { PId = 16, CId = 7 },
                new ProductInCategory { PId = 17, CId = 7 },
                new ProductInCategory { PId = 18, CId = 8 },
                new ProductInCategory { PId = 19, CId = 8 },
                new ProductInCategory { PId = 20, CId = 8 }
                );

            modelBuilder.Entity<Customer>().HasData(
                new Customer { CusId=1, CusName = "John Doe", CusAddress = "123 Main St", CusEmail = "john.doe@example.com", CusPhone = "555-1234" },
                new Customer { CusId=2, CusName = "Jane Smith", CusAddress = "456 Park Ave", CusEmail = "jane.smith@example.com", CusPhone = "555-5678" },
                new Customer { CusId=3, CusName = "Bob Johnson", CusAddress = "789 Elm St", CusEmail = "bob.johnson@example.com", CusPhone = "555-9012" },
                new Customer { CusId=4, CusName = "Ann Lee", CusAddress = "321 Oak Ln", CusEmail = "ann.lee@example.com", CusPhone = "555-3456" },
                new Customer { CusId=5, CusName = "Tom Wilson", CusAddress = "654 Maple Rd", CusEmail = "tom.wilson@example.com", CusPhone = "555-7890" },
                new Customer { CusId = 6, CusName = "Mary Brown", CusAddress = "246 Pine St", CusEmail = "mary.brown@example.com", CusPhone = "555-2468" },
                new Customer { CusId = 7, CusName = "David Lee", CusAddress = "135 Oak Ave", CusEmail = "david.lee@example.com", CusPhone = "555-1357" },
                new Customer { CusId = 8, CusName = "Sarah Davis", CusAddress = "789 Maple St", CusEmail = "sarah.davis@example.com", CusPhone = "555-7891" },
                new Customer { CusId = 9, CusName = "Mike Johnson", CusAddress = "246 Elm St", CusEmail = "mike.johnson@example.com", CusPhone = "555-2468" },
                new Customer { CusId = 10, CusName = "Lisa Smith", CusAddress = "135 Park Ave", CusEmail = "lisa.smith@example.com", CusPhone = "555-1357" },
                new Customer { CusId = 11, CusName = "Daniel Wilson", CusAddress = "789 Maple Rd", CusEmail = "daniel.wilson@example.com", CusPhone = "555-7891" },
                new Customer { CusId = 12, CusName = "Jessica Lee", CusAddress = "246 Oak Ln", CusEmail = "jessica.lee@example.com", CusPhone = "555-2468" },
                new Customer { CusId = 13, CusName = "Mark Brown", CusAddress = "135 Pine St", CusEmail = "mark.brown@example.com", CusPhone = "555-1357" },
                new Customer { CusId = 14, CusName = "Emily Davis", CusAddress = "789 Park Ave", CusEmail = "emily.davis@example.com", CusPhone = "555-7891" },
                new Customer { CusId = 15, CusName = "Andrew Johnson", CusAddress = "246 Elm St", CusEmail = "andrew.johnson@example.com", CusPhone = "555-2468" },
                new Customer { CusId = 16, CusName = "Rachel Smith", CusAddress = "135 Maple Rd", CusEmail = "rachel.smith@example.com", CusPhone = "555-1357" }
                );


            // any guid
            var roleId = new Guid("5768A50E-31B6-4933-B3B3-B0336F5656E6");
            var adminId = new Guid("7642BE16-2C21-40F0-81BB-CE85B30B0783");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "duccong29092003@gmail.com",
                NormalizedEmail = "duccong29092003@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abcd1234!"),
                SecurityStamp = string.Empty,
                FirstName = "Cong",
                LastName = "Do",
                Dob = new DateTime(2003, 09, 29)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
        }
    }
}
