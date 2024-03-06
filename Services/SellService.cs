using a2Algo.DTO.Purchase;
using a2Algo.DTO.Sell;
using a2Algo.Interfaces;
using a2Algo.Interfaces.Services;
using a2Algo.Models;
using a2Algo.StaticClasses;
using AutoMapper;


namespace a2Algo.Services
{
    public class SellService : ISellService
    {
        private readonly IUnitofWork unitofWork;
        private readonly IMapper mapper;
        public SellService(IUnitofWork _unitofWork, IMapper _mapper)
        {
            unitofWork = _unitofWork;
            mapper = _mapper;
        }
        public async Task<GlobalResponse> DeleteSellOrderAsync(int Id)
        {
            SaleModel? Order = await unitofWork.SaleRepository.GetByIdAsync(Id);
            if (Order is null)
            {
                return new GlobalResponse
                {
                    StatusCode = 404,
                    Message = Messages.NotFoundErrorMessage("Sale Order")
                };
            }

            bool removeOrder = unitofWork.SaleRepository.DeleteAsync(Order);
            int AffectedRow = await unitofWork.CommitAsync();

            if (AffectedRow > 0) return new GlobalResponse
            {
                Message = Messages.OnDeleteMessage("Order"),
                StatusCode = 200
            };

            return new GlobalResponse
            {
                Message = Messages.InternalServerErrorMessage,
                StatusCode = 500,
            };
        }

        public async Task<List<GettingSaleOrderDTO>> GetSellOrderAsync()
        {
            List<SaleModel> saleOrders = await unitofWork.SaleRepository.GetAllAsync();
            List<GettingSaleOrderDTO> gettingSaleOrder = saleOrders.Select(order => mapper.Map<GettingSaleOrderDTO>(order)).ToList();
            return gettingSaleOrder;    
        }

        public async Task<GettingSaleOrderDTO?> GetSellOrderByIdAsync(int Id)
        {
            SaleModel? saleOrder = await unitofWork.SaleRepository.GetByIdAsync(Id);
            return mapper.Map<GettingSaleOrderDTO?>(saleOrder);
        }

        public async Task<CreateResponse> PlaceSellOrderAsync(ForSellOrderDTO sellOrder)
        {
            SaleModel Order = mapper.Map<SaleModel>(sellOrder);
            bool Response = await unitofWork.SaleRepository.CreateAsync(Order);

            int affectedRow = await unitofWork.CommitAsync();

            if (affectedRow > 0)
                return new CreateResponse
                {
                    StatusCode = 201,
                    Message = Messages.OnCreateMessage("Sale order"),
                    Id = Order.Id,
                };

            return new CreateResponse { StatusCode = 500, Message = Messages.InternalServerErrorMessage };
        }
        
        public async Task<GlobalResponse> UpdateSellOrderAsync(UpdatingSaleOrderDTO sellOrder)
        {
            SaleModel? Order = await unitofWork.SaleRepository.GetByIdAsync(sellOrder.Id);
            if (Order is null)
            {
                return new GlobalResponse
                {
                    StatusCode = 404,
                    Message = Messages.NotFoundErrorMessage("Sell Order Id")
                };
            }

            Order.SalePrice = sellOrder.SalePrice;
            Order.SellingQuantity = sellOrder.SellingQuantity;
            Order.ProductId = sellOrder.ProductId;

            bool updateOrder = unitofWork.SaleRepository.UpdateAsync(Order);
            int AffactedRows = await unitofWork.CommitAsync();

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
    }
}
