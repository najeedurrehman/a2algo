using a2Algo.DTO.Purchase;
using a2Algo.DTO.Sell;
using a2Algo.Models;

namespace a2Algo.Interfaces.Services
{
    public interface IPurchaseService
    {
        Task<CreateResponse> PlacePurchaseOrderAsync(PurchaseOrderDTO purchaseOrder);
        Task<GlobalResponse> UpdatePurchaseOrderAsync(UpdatingPurchaseOrderDTO purchaseOrder);
        Task<GlobalResponse> DeletePurchaseOrderAsync(int Id);

        Task<List<GettingPurchaseOrderDTO>> GetAllPurchaseOrdersAsync();
        
        Task<GettingPurchaseOrderDTO?> GetPurchaseOrderByIdAsync(int Id);   

    }
}