using a2Algo.DTO.Product;
using a2Algo.Models;

namespace a2Algo.Interfaces
{
    public interface IProductRepository : IRepository<ProductModel> 
    {
        Task<List<ProductForUserDTO>> ProductForUserAsync();
        Task ProductForAdminAsync();

        Task ProductWithBuyingOrderAsync();

        Task<List<ProductWithSellingDetailDTO>> ProductWithSellingOrderAsync();
    }
}
