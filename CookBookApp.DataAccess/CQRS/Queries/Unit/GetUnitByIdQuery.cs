using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Queries.Unit
{
    public class GetUnitByIdQuery : QueryBase<DataAccess.Entities.Unit>
    {
        public int UnitId { get; set; }
        public override async Task<Entities.Unit> Execute(CookBookAppContext context)
        {
            return await context.Unit.FirstOrDefaultAsync(x => x.Id == UnitId);
        }
    }
}
