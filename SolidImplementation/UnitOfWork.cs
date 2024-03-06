using a2Algo.Context;
using a2Algo.Interfaces;
using a2Algo.Models;

namespace a2Algo.SolidImplementation
{
    public class UnitOfWork : IUnitofWork
    {
        private readonly InventoryContext context;
        private readonly IProductRepository productRepository;
        private readonly IRepository<SaleModel> saleRepository;
        private readonly IRepository<PurcahseModel> purchaseRepository;

        public UnitOfWork(InventoryContext _context, IProductRepository productRepo, IRepository<SaleModel> saleRepo, IRepository<PurcahseModel> purchaseRepo)
        {
            context = _context;
            productRepository = productRepo;
            saleRepository = saleRepo;
            purchaseRepository = purchaseRepo;
        }

        public IProductRepository ProductRepository => productRepository;

        public IRepository<SaleModel> SaleRepository => saleRepository;

        public IRepository<PurcahseModel> PurchaseRepository => purchaseRepository;

        public async Task<int> CommitAsync()
        {
            int result = await context.SaveChangesAsync();
            return result;
        }
    }
}
