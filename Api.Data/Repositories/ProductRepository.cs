using Api.Core.Interfaces;
using Api.Core.Models;
using Api.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
