using a2Algo.DTO.Product;
using a2Algo.Interfaces;
using a2Algo.Interfaces.Services;
using a2Algo.Models;
using a2Algo.SolidImplementation;
using a2Algo.StaticClasses;
using AutoMapper;

namespace a2Algo.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitofWork UOW;
        private readonly IMapper mapper;
        public ProductService(IUnitofWork unitofWork, IMapper _mapper)
        {
            UOW = unitofWork;   
            mapper = _mapper;   
        }

        public async Task<CreateResponse> AddProduct(CreateProductDTO product)
        {

            ProductModel Product = mapper.Map<ProductModel>(product);   
            bool Response = await UOW.ProductRepository.CreateAsync(Product);
            
            int affectedRows = await UOW.CommitAsync();

            if ( affectedRows > 0)
                return new CreateResponse {
                    StatusCode = 201,
                    Message = Messages.OnCreateMessage($"Product named {product.ProductName}"),
                    Id = Product.Id,    
                };

            return new CreateResponse { StatusCode = 500, Message = Messages.InternalServerErrorMessage };
        }

        public async Task<List<ProductDTO>> GetAllAsync()
        {
            var ProductList = await UOW.ProductRepository.GetAllAsync();
            var Products = ProductList.Select(p => mapper.Map<ProductDTO>(p)).ToList();

            return Products;
        }

        public async Task<GlobalResponse> DeleteProduct(int Id)
        {
            ProductModel? Product = await UOW.ProductRepository.GetByIdAsync(Id);
            if (Product is null)
            {
                return new GlobalResponse
                {
                    StatusCode = 404,
                    Message = Messages.NotFoundErrorMessage("Product Id")
                };
            }

            bool RemoveProduct = UOW.ProductRepository.DeleteAsync(Product);
            int AffectedRow = await UOW.CommitAsync();

            if (AffectedRow > 0) return new GlobalResponse
            {
                Message = Messages.OnDeleteMessage("Product"),
                StatusCode = 200
            };

            return new GlobalResponse
            {
                Message = Messages.InternalServerErrorMessage,
                StatusCode = 500,
            };
        }

        public async Task<GlobalResponse> UpdateProduct( UpdateProductDTO product)
        {
            ProductModel? Product = await UOW.ProductRepository.GetByIdAsync(product.Id);
            if (Product is null)
            {
                return new GlobalResponse
                {
                    StatusCode = 404,
                    Message = Messages.NotFoundErrorMessage("Product")
                };
            }

            Product.ProductName = product.ProductName;  
            Product.ProductDescription = product.ProductDescription;    

            
            bool UpdateProduct = UOW.ProductRepository.UpdateAsync(Product);    
            int AffactedRows = await UOW.CommitAsync();

            if (AffactedRows > 0) return new GlobalResponse
            {
                StatusCode = 200,
                Message = Messages.OnUpdateMessage
            };

            return new GlobalResponse
            {
                Message = Messages.InternalServerErrorMessage,
                StatusCode = 500,
            };
        }

        public async Task<ProductDTO?> GetProductById(int Id)
        {
            ProductModel? Product = await UOW.ProductRepository.GetByIdAsync(Id);
            return mapper.Map<ProductDTO?>(Product);    
        
        }

        public async Task<List<ProductForUserDTO>> ProductForUser()
        {
            return await UOW.ProductRepository.ProductForUserAsync();
        }


        public async Task<List<ProductWithSellingDetailDTO>> ProductWithSellingDetail()
        {
            return await UOW.ProductRepository.ProductWithSellingOrderAsync();
        }
    }
}
