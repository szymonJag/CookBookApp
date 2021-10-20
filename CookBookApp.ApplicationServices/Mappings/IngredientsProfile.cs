using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.Ingredients;

namespace CookBookApp.ApplicationServices.Mappings
{
    public class IngredientsProfile : Profile
    {
        public IngredientsProfile()
        {
            this.CreateMap<DataAccess.Entities.Ingredient, API.Domain.Models.Ingredient>()
                .ForMember(x => x.Value, y => y.MapFrom(z => z.Value))
                .ForMember(x => x.ProductName, y => y.MapFrom(z => z.Product.Name))
                .ForMember(x => x.Unit, y => y.MapFrom(z => z.Unit.Name));

            this.CreateMap<AddIngredientRequest, DataAccess.Entities.Ingredient>()
                .ForMember(x => x.ProductId, y => y.MapFrom(z => z.ProductId))
                .ForMember(x => x.UnitId, y => y.MapFrom(z => z.UnitId))
                .ForMember(x => x.RecipeId, y => y.MapFrom(z => z.UnitId))
                .ReverseMap();

            this.CreateMap<DataAccess.Entities.Ingredient, UpdateIngredientRequest>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.ProductId, y => y.MapFrom(z => z.ProductId))
                .ForMember(x => x.UnitId, y => y.MapFrom(z => z.UnitId))
                .ForMember(x => x.RecipeId, y => y.MapFrom(z => z.RecipeId))
                .ForMember(x => x.Value, y => y.MapFrom(z => z.Value))
                .ReverseMap();
        }
    }
}
