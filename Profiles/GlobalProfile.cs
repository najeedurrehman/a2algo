using a2Algo.DTO.Product;
using a2Algo.DTO.Purchase;
using a2Algo.DTO.Sell;
using a2Algo.Models;
using AutoMapper;

namespace a2Algo.Profiles
{
    public class GlobalProfile : Profile
    {
        public GlobalProfile()
        {
            /* PRODUCT BLOCK */
            CreateMap<CreateProductDTO, ProductModel>();
            CreateMap<ProductModel, ProductDTO>();
            CreateMap<UpdateProductDTO, ProductModel>();

            /* PURCHASING BLOCK */
            CreateMap<PurchaseOrderDTO, PurcahseModel>();
            CreateMap<PurcahseModel, GettingPurchaseOrderDTO>();

            /* SELLING BLOCK */

            CreateMap<ForSellOrderDTO, SaleModel>();
            CreateMap<SaleModel, GettingSaleOrderDTO>();
        }
    }
}
