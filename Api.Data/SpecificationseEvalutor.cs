using Api.Core.Models;
using Api.Core.Specifications;
using Api.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data
{
    public static class SpecificationseEvalutor<T> where T : BaseModel
    {
        //_context.Setof<>() 
        public static IQueryable<T> GetQuery(IQueryable<T> context , BaseSpecifications<T> specifications)
        {
            IQueryable<T> query = context;

            if(specifications.Criteria is not null) 
            {
                query.Where(specifications.Criteria);
            }

            //.Include(P => P.Brand).Include(P => P.Type).; */
            query = specifications.Includes.Aggregate(query,(currentQuery,IncludedQuery) => currentQuery.Include(IncludedQuery));

            return query;
        }
    }
}
