using Microsoft.AspNetCore.Http;
using PhoneShop.Data.Entities;
using PhoneShop.ViewModels.Catalog.Product;
using PhoneShop.ViewModels.Catalog.ProductImage;
using PhoneShop.ViewModels.Common;

namespace PhoneShop.BusinessLogic.Catalog.Products
{
    public interface IProductService
    {
        //Trả về mã sản phẩm vừa tạo
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int productId);


        Task<bool> UpdatePrice(int productId, decimal newPrice);

        Task<bool> UpdateStock(int productId, int addedQuantity);

        //--------------------------

        //Lấy ra list data product sau khi search
        Task<Product> GetById(int productId);
        Task<PagedResult<Product>> GetAllPaging(GetManageProductPagingRequest request);
        Task<PagedResult<Product>> GetAllByCategoryId(GetPublicProductPagingRequest request);

        Task<int> AddImage(int productId, ProductImageCreateRequest request);
        Task<int> RemoveImage(int imageId);
        Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request);
        Task<ProductImageViewModel> GetImageById(int imageId);
        Task<List<ProductImageViewModel>> GetListImages(int productId);


    }
}
