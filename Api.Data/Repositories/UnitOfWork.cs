using Api.Core.Interfaces;
using Api.Data.Data;

namespace Api.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext context;

        private readonly IProductRepository _productRepository;

        public UnitOfWork(ApplicationContext context , IProductRepository productRepository)
        {
            this.context = context;
            _productRepository = productRepository;
        }

        public IProductRepository ProductRepository { get => _productRepository; }

        public async Task<int> SaveChanges()
        {
            return await context.SaveChangesAsync();
        }
    }
}
