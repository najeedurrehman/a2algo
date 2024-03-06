using a2Algo.DTO.Purchase;
using a2Algo.DTO.Sell;
using a2Algo.Interfaces;
using a2Algo.Interfaces.Services;
using a2Algo.Models;
using a2Algo.SolidImplementation;
using a2Algo.StaticClasses;
using AutoMapper;

namespace a2Algo.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IUnitofWork unitofWork;
        private readonly IMapper mapper;
        public PurchaseService(IUnitofWork _unitofWork, IMapper _mapper)
        {
            unitofWork = _unitofWork;
            mapper = _mapper;
        }

        public async Task<GlobalResponse> DeletePurchaseOrderAsync(int Id)
        {
            PurcahseModel? Order = await unitofWork.PurchaseRepository.GetByIdAsync(Id);
            if (Order is null)
            {
                return new GlobalResponse
                {
                    StatusCode = 404,
                    Message = Messages.NotFoundErrorMessage("Purchase Order")
                };
            }

            bool RemoveProduct = unitofWork.PurchaseRepository.DeleteAsync(Order);
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

        public async Task<List<GettingPurchaseOrderDTO>> GetAllPurchaseOrdersAsync()
        {
            List<PurcahseModel> purchaseOrders = await unitofWork.PurchaseRepository.GetAllAsync();
            List<GettingPurchaseOrderDTO> gettingPurchaseOrder = purchaseOrders.Select(order => mapper.Map<GettingPurchaseOrderDTO>(order)).ToList();
            return gettingPurchaseOrder;
        }

        public async Task<GettingPurchaseOrderDTO?> GetPurchaseOrderByIdAsync(int Id)
        {
            PurcahseModel? purchaseOrder = await unitofWork.PurchaseRepository.GetByIdAsync(Id);
            return mapper.Map<GettingPurchaseOrderDTO?>(purchaseOrder);
        }

        public async Task<CreateResponse> PlacePurchaseOrderAsync(PurchaseOrderDTO purchaseOrder)
        {
            PurcahseModel Order = mapper.Map<PurcahseModel>(purchaseOrder);
            bool Response = await unitofWork.PurchaseRepository.CreateAsync(Order);

            int affectedRow = await unitofWork.CommitAsync();

            if (affectedRow > 0)
                return new CreateResponse
                {
                    StatusCode = 201,
                    Message = Messages.OnCreateMessage("Product order"),
                    Id = Order.Id,
                };

            return new CreateResponse { StatusCode = 500, Message = Messages.InternalServerErrorMessage };

        }

        public async Task<GlobalResponse> UpdatePurchaseOrderAsync(UpdatingPurchaseOrderDTO purchaseOrder)
        {
            PurcahseModel? Order = await unitofWork.PurchaseRepository.GetByIdAsync(purchaseOrder.Id);
            if (Order is null)
            {
                return new GlobalResponse
                {
                    StatusCode = 404,
                    Message = Messages.NotFoundErrorMessage("Order")
                };
            }

            Order.PurchasingQuantity = purchaseOrder.PurchasingQuantity;
            Order.PurchasingPrice = purchaseOrder.PurchasingPrice;
            Order.ProductId = purchaseOrder.ProductId;


            bool updateOrder = unitofWork.PurchaseRepository.UpdateAsync(Order);
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
