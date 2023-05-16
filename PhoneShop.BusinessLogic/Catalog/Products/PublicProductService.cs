using Microsoft.EntityFrameworkCore;
using PhoneShop.Data.EF;
using PhoneShop.ViewModels.Catalog;
using PhoneShop.ViewModels.Common;

namespace PhoneShop.BusinessLogic.Catalog.Products
{

    public class PublicProductService : IPublicProductService
    {
        private readonly PhoneShopDbContext _context;
        public PublicProductService(PhoneShopDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductViewModel>> GetAll()
        {
            //1. Select Join
            var query = from p in _context.Products
                        join pic in _context.ProductInCategories on p.PId equals pic.PId
                        join c in _context.Categories on pic.CId equals c.CId
                        select new { p, pic };

            var data = await query
                .Select(e => new ProductViewModel()
                {
                    PId = e.p.PId,
                    PName = e.p.PName,
                    MId = e.p.MId,
                    PDescription = e.p.PDescription,
                    PColor = e.p.PColor,
                    PStorage = e.p.PStorage,
                    PRam = e.p.PRam,
                    PScreenSize = e.p.PScreenSize,
                    PResolution = e.p.PResolution,
                    POperatingSystem = e.p.POperatingSystem,
                    PCamera = e.p.PCamera,
                    PBatteryCapacity = e.p.PBatteryCapacity,
                    PConnectivity = e.p.PConnectivity,
                    PWeight = e.p.PWeight,
                    PDimension = e.p.PDimension,
                    PPrice = e.p.PPrice,
                    POriginalPrice = e.p.POriginalPrice,
                    PStock = e.p.PStock,

                }).ToListAsync();

            return data;
        }


        //Lấy ra các sản phẩm trong category nào đó
        public async Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest request)
        {
            //1. Select Join
            var query = from p in _context.Products
                        join pic in _context.ProductInCategories on p.PId equals pic.PId
                        join c in _context.Categories on pic.CId equals c.CId
                        select new { p, pic };
            //2. Filter

            if (request.CategoryId.HasValue && request.CategoryId.Value > 0)
            {
                query = query.Where(p => p.pic.Category.CId == request.CategoryId);
            }
            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(e => new ProductViewModel()
                {
                    PId = e.p.PId,
                    PName = e.p.PName,
                    MId = e.p.MId,
                    PDescription = e.p.PDescription,
                    PColor = e.p.PColor,
                    PStorage = e.p.PStorage,
                    PRam = e.p.PRam,
                    PScreenSize = e.p.PScreenSize,
                    PResolution = e.p.PResolution,
                    POperatingSystem = e.p.POperatingSystem,
                    PCamera = e.p.PCamera,
                    PBatteryCapacity = e.p.PBatteryCapacity,
                    PConnectivity = e.p.PConnectivity,
                    PWeight = e.p.PWeight,
                    PDimension = e.p.PDimension,
                    PPrice = e.p.PPrice,
                    POriginalPrice = e.p.POriginalPrice,
                    PStock = e.p.PStock,

                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<ProductViewModel>()
            {
                TotalRecord = totalRow,
                Items = data
            };
            return pagedResult;
        }

    }
}
