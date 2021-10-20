using MediatR;

namespace CookBookApp.ApplicationServices.API.Domain.Ingredients
{
    public class UpdateIngredientRequest : RequestBase, IRequest<UpdateIngredientResponse>
    {
        public int Id { get; set; }
        public int UnitId { get; set; }
        public int RecipeId { get; set; }
        public int ProductId { get; set; }
        public double Value { get; set; }
    }
}
