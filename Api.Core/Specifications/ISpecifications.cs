using Api.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Specifications
{
    public interface ISpecifications<T> where T : BaseModel
    {
        //signature 
        /*_context.Set<TEntity>().Where().Include(P => P.Brand).Include(P => P.Type).;*/
        //.Where()
        Expression<Func<T,bool>> Criteria { get; set; }

        //.Include(P => P.Brand).Include(P => P.Type).;*/

        List<Expression<Func<T,object>>> Includes { get; set; } 
        


    }
}
