using a2Algo.DTO.Product;
using a2Algo.Models;

namespace a2Algo.Interfaces.Services
{
    public interface IProductService
    {
        Task<CreateResponse> AddProduct(CreateProductDTO product);

        Task<List<ProductDTO>> GetAllAsync();

        Task<GlobalResponse> DeleteProduct(int Id);

        Task<GlobalResponse> UpdateProduct(UpdateProductDTO product);

        Task<ProductDTO?> GetProductById(int Id);
         
        Task<List<ProductForUserDTO>> ProductForUser();
        Task<List<ProductWithSellingDetailDTO>> ProductWithSellingDetail();
    }
}
