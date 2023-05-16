using Microsoft.AspNetCore.Http;
using PhoneShop.ViewModels.Catalog;
using PhoneShop.ViewModels.Catalog.Manage;
using PhoneShop.ViewModels.Common;

namespace PhoneShop.BusinessLogic.Catalog.Products
{
    public interface IManageProductService
    {
        //Trả về mã sản phẩm vừa tạo
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int productId);

        Task<ProductViewModel> GetById(int productId, string languageId);

        Task<bool> UpdatePrice(int productId, decimal newPrice);

        Task<bool> UpdateStock(int productId, int addedQuantity);

        //--------------------------

        //Lấy ra list data product sau khi search
        Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);


    }
}
