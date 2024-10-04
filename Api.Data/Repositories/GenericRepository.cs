using Api.Core.Interfaces;
using Api.Core.Models;
using Api.Core.Specifications;
using Api.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseModel
    {
        private readonly ApplicationContext _context;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            if (typeof(TEntity) == typeof(Product)) 
            {
                return (IEnumerable<TEntity>) await _context.Products.Include(P => P.Brand).Include(P => P.Type).ToListAsync();
            }
           return await _context.Set<TEntity>().ToListAsync();
        }



        public async Task<TEntity> GetByIdAsync(int id)
        {
            //Invalid query (For test)
            return await _context.Set<TEntity>().FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsyncSpec(BaseSpecifications<TEntity> specs)
        {
            return await ApplySpecifications(specs).ToListAsync();
        }


        public async Task<TEntity> GetByIdAsyncSpec(BaseSpecifications<TEntity> specs)
        {
            return await ApplySpecifications(specs).FirstOrDefaultAsync();
        }

         public IQueryable<TEntity> ApplySpecifications(BaseSpecifications<TEntity> specifications) 
        {
            return  SpecificationseEvalutor<TEntity>.GetQuery(_context.Set<TEntity>(), specifications);
        }
    } 
}
