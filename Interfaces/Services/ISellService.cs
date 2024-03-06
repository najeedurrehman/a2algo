using a2Algo.DTO.Sell;
using a2Algo.Models;

namespace a2Algo.Interfaces.Services
{
    public interface ISellService
    {
        Task<List<GettingSaleOrderDTO>> GetSellOrderAsync();

        Task<CreateResponse> PlaceSellOrderAsync(ForSellOrderDTO sellOrder);
        Task<GlobalResponse> DeleteSellOrderAsync(int Id);
        Task<GlobalResponse> UpdateSellOrderAsync(UpdatingSaleOrderDTO globalSellOrder);

        Task<GettingSaleOrderDTO?> GetSellOrderByIdAsync(int Id);
    }
}
