using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.RecipeFoodType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.Mappings
{
    public class RecipeFoodTypeProfile : Profile
    {
        public RecipeFoodTypeProfile()
        {
            this.CreateMap<DataAccess.Entities.RecipeFoodType, API.Domain.Models.RecipeFoodType>()
                .ForMember(x => x.FoodTypeName, y => y.MapFrom(z => z.FoodType.Name))
                .ReverseMap();

            this.CreateMap<AddRecipeFoodTypeRequest, DataAccess.Entities.RecipeFoodType>()
                .ForMember(x => x.FoodTypeId, y => y.MapFrom(z => z.FoodTypeId))
                .ForMember(x => x.RecipeId, y => y.MapFrom(z => z.RecipeId))
                .ReverseMap();

            this.CreateMap<UpdateRecipeFoodTypeRequest, DataAccess.Entities.RecipeFoodType>()
                .ForMember(x => x.FoodTypeId, y => y.MapFrom(z => z.FoodTypeId))
                .ForMember(x => x.RecipeId, y => y.MapFrom(z => z.RecipeId))
                .ReverseMap();
                
        }
    }
}
