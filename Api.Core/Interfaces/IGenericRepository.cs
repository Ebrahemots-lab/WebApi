using Api.Core.Models;
using Api.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseModel
    {
        public Task<IEnumerable<TEntity>> GetAllAsync();

        public Task<TEntity> GetByIdAsync(int id);

        Task<IEnumerable<TEntity>> GetAllAsyncSpec(BaseSpecifications<TEntity> specs);

        Task<TEntity> GetByIdAsyncSpec(BaseSpecifications<TEntity> specs);

        Task Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
