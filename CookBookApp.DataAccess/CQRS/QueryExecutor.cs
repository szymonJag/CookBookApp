using CookBookApp.DataAccess.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly CookBookAppContext context;

        public QueryExecutor(CookBookAppContext context)
        {
            this.context = context;
        }
        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(this.context);
        }
    }
}
