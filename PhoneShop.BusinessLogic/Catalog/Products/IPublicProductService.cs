using PhoneShop.ViewModels.Catalog;
using PhoneShop.ViewModels.Common;

namespace PhoneShop.BusinessLogic.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest request);
        Task<List<ProductViewModel>> GetAll();


    }
}
