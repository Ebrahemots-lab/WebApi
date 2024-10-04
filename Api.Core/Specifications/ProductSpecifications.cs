using Api.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Specifications
{
    public class ProductSpecifications : BaseSpecifications<Product>
    {
        public ProductSpecifications()
        {
            Includes.Add(P => P.Brand);
            Includes.Add(P => P.Type);
        }

        public ProductSpecifications(Expression<Func<Product,bool>> criteria)
        {
            Criteria = criteria;
        }
    }
}
