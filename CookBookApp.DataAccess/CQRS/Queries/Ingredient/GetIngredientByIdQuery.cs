using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.DataAccess.CQRS.Queries.Ingredient
{
    public class GetIngredientByIdQuery : QueryBase<DataAccess.Entities.Ingredient>
    {
        public int IngredientId { get; set; }
        public override Task<Entities.Ingredient> Execute(CookBookAppContext context)
        {
            return context.Ingredient.FirstOrDefaultAsync(x => x.Id == IngredientId);
        }
    }
}
