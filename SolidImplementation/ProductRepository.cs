using a2Algo.Context;
using a2Algo.DTO.Product;
using a2Algo.Interfaces;
using a2Algo.Models;
using Microsoft.EntityFrameworkCore;

namespace a2Algo.SolidImplementation
{
    public class ProductRepository : Repository<ProductModel>, IProductRepository
    {

        public ProductRepository(InventoryContext context) : base(context)
        {
        }

        public Task ProductForAdminAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductForUserDTO>> ProductForUserAsync()
        {
            List<ProductModel> Products = await DataContext.Include(p => p.Purcahse).ToListAsync();
            List<ProductForUserDTO> UserProduct = new List<ProductForUserDTO>();
            foreach (var Product in Products)
            {
                int availableStack = Product.Purcahse.Sum(p => p.PurchasingQuantity);

                decimal lastpurchasedPrice = 0;
                if (Product.Purcahse.Any())
                {
                    lastpurchasedPrice = Product.Purcahse.OrderByDescending(param => param.Id).First().PurchasingPrice;
                }

                ProductForUserDTO producetDetail = new()
                {
                    Id = Product.Id,
                    ProductDescription = Product.ProductDescription,
                    ProductName = Product.ProductName,
                    AvilableStock = availableStack,
                    Price = lastpurchasedPrice
                };

                UserProduct.Add(producetDetail);
            }

            return UserProduct;
        }

        public Task ProductWithBuyingOrderAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductWithSellingDetailDTO>> ProductWithSellingOrderAsync()
        {
            List<ProductModel> Products = await DataContext.Include(p => p.Sale).ToListAsync();
            List<ProductWithSellingDetailDTO> SellingDetail = new List<ProductWithSellingDetailDTO>();

            foreach (var Product in Products)
            {
                if (Product.Sale.Any())
                {
                    ProductWithSellingDetailDTO productSelling = new ProductWithSellingDetailDTO();
                    foreach (var sales in Product.Sale)
                    {
                        productSelling.Id = sales.Id;
                        productSelling.ProductName = Product.ProductName;
                        productSelling.SellingQuantity = sales.SellingQuantity;
                        productSelling.Price = sales.SalePrice;
                        productSelling.OrderDate = sales.SellingDate;
                    }
                    SellingDetail.Add(productSelling);
                }

            }

            return SellingDetail;
        }
    }
}
