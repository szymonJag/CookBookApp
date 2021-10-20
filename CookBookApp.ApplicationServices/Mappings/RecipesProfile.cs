using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.Recipes;

namespace CookBookApp.ApplicationServices.Mappings
{
    public class RecipesProfile : Profile
    {
        public RecipesProfile()
        {
            this.CreateMap<DataAccess.Entities.Recipe, API.Domain.Models.Recipe>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ForMember(x => x.Ingredients, y => y.MapFrom(z => z.Ingredients))
                .ForMember(x => x.FoodTypes, y => y.MapFrom(z => z.FoodTypes))
                .ForMember(x => x.IsAcceptedByAdmin, y => y.MapFrom(z => z.IsAcceptedByAdmin))
                .ForMember(x => x.Author, y => y.MapFrom(z => z.Author))
                .ReverseMap();

            this.CreateMap<AddRecipeRequest, DataAccess.Entities.Recipe>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Description, y => y.MapFrom(y => y.Description))
                .ReverseMap();

            this.CreateMap<DataAccess.Entities.Recipe, UpdateRecipeRequest>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description))
                .ReverseMap();

        }
    }
}
