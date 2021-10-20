using CookBookApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Queries
{
    public class GetUnitsQuery : QueryBase<List<Entities.Unit>>
    {
        public override Task<List<Entities.Unit>> Execute(CookBookAppContext context)
        {
            return context.Unit.ToListAsync();
        }
    }
}
