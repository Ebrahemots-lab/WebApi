using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Interfaces
{

    //this class will handle all connections between repository and database
    public interface IUnitOfWork
    {

        public IProductRepository ProductRepository { get; }


        Task<int> SaveChanges();

    }
}
