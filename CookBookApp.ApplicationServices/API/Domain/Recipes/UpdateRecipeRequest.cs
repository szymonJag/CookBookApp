using CookBookApp.ApplicationServices.API.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.API.Domain.Recipes
{
    public class UpdateRecipeRequest : RequestBase, IRequest<UpdateRecipeResponse>
    {
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
