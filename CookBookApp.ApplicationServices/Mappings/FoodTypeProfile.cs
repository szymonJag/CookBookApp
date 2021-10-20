using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.FoodTypes;

namespace CookBookApp.ApplicationServices.Mappings
{
    public class FoodTypeProfile : Profile
    {
        public FoodTypeProfile()
        {
            this.CreateMap<API.Domain.Models.FoodType, DataAccess.Entities.FoodType>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.FoodTypeName))
                .ReverseMap();

            this.CreateMap<AddFoodTypeRequest, DataAccess.Entities.FoodType>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.FoodTypeName))
                .ReverseMap();

            this.CreateMap<UpdateFoodTypeRequest, DataAccess.Entities.FoodType>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.FoodTypeName))
                .ReverseMap();
        }
    }
}
