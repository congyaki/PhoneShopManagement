using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PhoneShop.BusinessLogic.Common;
using PhoneShop.Data.EF;
using PhoneShop.Data.Entities;
using PhoneShop.Utilities.Exceptions;
using PhoneShop.ViewModels.Catalog.Product;
using PhoneShop.ViewModels.Catalog.ProductImage;
using PhoneShop.ViewModels.Common;
using System.Net.Http.Headers;
using static System.Net.Mime.MediaTypeNames;

namespace PhoneShop.BusinessLogic.Catalog.Products
{
    public class ProductService : IProductService
    {
        private readonly PhoneShopDbContext _context; 
        private readonly IStorageService _storageService;
        public ProductService(PhoneShopDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }
        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                PName = request.PName,
                MId = request.MId,
                PDescription = request.PDescription,
                PColor = request.PColor,
                PStorage = request.PStorage,
                PRam = request.PRam,
                PScreenSize = request.PScreenSize,
                PResolution = request.PResolution,
                POperatingSystem = request.POperatingSystem,
                PCamera = request.PCamera,
                PBatteryCapacity = request.PBatteryCapacity,
                PConnectivity = request.PConnectivity,
                PWeight = request.PWeight,
                PDimension = request.PDimension,
                PPrice = request.PPrice,
                POriginalPrice = request.POriginalPrice,
                PStock = request.PStock,
            };
            //Save Image
            if (request.ThumbnailImage != null)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        PICaption = "Thumbnail image",
                        PIPath = await this.SaveFile(request.ThumbnailImage),
                        PIIsDefault = true,
                        PISortOrder = 1
                    }
                };
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.PId;
        }
        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.PId);

            if (product == null) throw new PhoneShopException($"Cannot find a product with id: {request.PId}");

            product.PName = request.PName;
            product.PDescription = request.PDescription;
            product.PColor = request.PColor;
            product.PStorage = request.PStorage;
            product.PRam = request.PRam;
            product.PScreenSize = request.PScreenSize;
            product.PResolution = request.PResolution;
            product.POperatingSystem = request.POperatingSystem;
            product.PCamera = request.PCamera;
            product.PBatteryCapacity = request.PBatteryCapacity;
            product.PConnectivity = request.PConnectivity;
            product.PWeight = request.PWeight;
            product.PDimension = request.PDimension;

            //Save image
            if (request.ThumbnailImage != null)
            {
                var thumbnailImage = await _context.ProductImages.FirstOrDefaultAsync(i => i.PIIsDefault == true && i.PId == request.PId);
                if (thumbnailImage != null)
                {
                    thumbnailImage.PIPath = await this.SaveFile(request.ThumbnailImage);
                    _context.ProductImages.Update(thumbnailImage);
                }
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new PhoneShopException($"Cannot find a product: {productId}");

            var images = _context.ProductImages.Where(i => i.PId == productId);
            foreach (var image in images)
            {
                await _storageService.DeleteFileAsync(image.PIPath);
            }

            _context.Products.Remove(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<Product> GetById(int productId)
        {
            var product = await _context.Products.FindAsync(productId);

            var productViewModel = new Product()
            {
                PId = product.PId,
                PName = product.PName,
                MId= product.MId,
                PDescription = product.PDescription,
                PColor = product.PColor,
                PStorage = product.PStorage,
                PRam = product.PRam,
                PScreenSize = product.PScreenSize,
                PResolution = product.PResolution,
                POperatingSystem = product.POperatingSystem,
                PCamera = product.PCamera,
                PBatteryCapacity = product.PBatteryCapacity,
                PConnectivity = product.PConnectivity,
                PWeight = product.PWeight,
                PDimension = product.PDimension,
        };
            return productViewModel;
        }

        public async Task<PagedResult<Product>> GetAllPaging(GetManageProductPagingRequest request)
        {
            //1. Select Join
            var query = from p in _context.Products
                        join pic in _context.ProductInCategories on p.PId equals pic.PId
                        join c in _context.Categories on pic.CId equals c.CId
                        select new { p, pic };
            //2. Filter
            if(!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(e => e.p.PName.Contains(request.Keyword));
            if (request.CategoryIds != null && request.CategoryIds.Count > 0)
            {
                query = query.Where(p => request.CategoryIds.Contains(p.pic.CId));
            }
            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(e => new Product()
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
                    Manufacturer = e.p.Manufacturer,
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<Product>()
            {
                TotalRecord = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }

        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new PhoneShopException($"Cannot find a product with id: {productId}");
            product.PPrice = newPrice;
            //return TRUE
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStock(int productId, int addedQuantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new PhoneShopException($"Cannot find a product with id: {productId}");
            product.PStock += addedQuantity;
            //return TRUE
            return await _context.SaveChangesAsync() > 0;
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            //Lấy ra tên file
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            //Tạo ra file mới
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }


        public async Task<int> AddImage(int productId, ProductImageCreateRequest request)
        {
            var productImage = new ProductImage()
            {
                PICaption = request.PICaption,
                PIIsDefault = request.PIIsDefault,
                PId = productId,
                PISortOrder = request.PISortOrder
            };

            if (request.ImageFile != null)
            {
                productImage.PIPath = await this.SaveFile(request.ImageFile);
            }
            _context.ProductImages.Add(productImage);
            await _context.SaveChangesAsync();
            return productImage.PIId;
        }

        public async Task<int> RemoveImage(int imageId)
        {
            var productImage = await _context.ProductImages.FindAsync(imageId);
            if (productImage == null)
                throw new PhoneShopException($"Cannot find an image with id {imageId}");
            _context.ProductImages.Remove(productImage);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request)
        {
            var productImage = await _context.ProductImages.FindAsync(imageId);
            if (productImage == null)
                throw new PhoneShopException($"Cannot find an image with id {imageId}");

            if (request.ImageFile != null)
            {
                productImage.PIPath = await this.SaveFile(request.ImageFile);
            }
            _context.ProductImages.Update(productImage);
            return await _context.SaveChangesAsync();
        }

        public async Task<ProductImageViewModel> GetImageById(int imageId)
        {
            var image = await _context.ProductImages.FindAsync(imageId);
            if (image == null)
                throw new PhoneShopException($"Cannot find an image with id {imageId}");

            var viewModel = new ProductImageViewModel()
            {
                PICaption = image.PICaption,
                PIId = image.PIId,
                PIPath = image.PIPath,
                PIIsDefault = image.PIIsDefault,
                PId = image.PId,
                PISortOrder = image.PISortOrder
            };
            return viewModel;
        }

        public async Task<List<ProductImageViewModel>> GetListImages(int productId)
        {
            return await _context.ProductImages.Where(x => x.PId == productId)
                .Select(i => new ProductImageViewModel()
                {
                    PICaption = i.PICaption,
                    PIId = i.PIId,
                    PIPath = i.PIPath,
                    PIIsDefault = i.PIIsDefault,
                    PId = i.PId,
                    PISortOrder = i.PISortOrder
                }).ToListAsync();
        }

        public async Task<PagedResult<Product>> GetAllByCategoryId(GetPublicProductPagingRequest request)
        {
            //1. Select Join
            var query = from p in _context.Products
                        join pic in _context.ProductInCategories on p.PId equals pic.PId
                        join c in _context.Categories on pic.CId equals c.CId
                        select new { p, pic };
            //2. Filter
            if (request.CategoryId.HasValue && request.CategoryId.Value > 0)
                query = query.Where(e => e.pic.CId == request.CategoryId);
            
            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(e => new Product()
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
            var pagedResult = new PagedResult<Product>()
            {
                TotalRecord = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };
            return pagedResult;
        }
    }
}
