using a2Algo.Models;

namespace a2Algo.Interfaces
{
    public interface IUnitofWork
    {
        public IProductRepository ProductRepository { get; }
        public IRepository<SaleModel> SaleRepository { get; }
        public IRepository<PurcahseModel> PurchaseRepository { get; }

        Task<int> CommitAsync();
    }
}
