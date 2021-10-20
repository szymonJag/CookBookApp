using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.Units;

namespace CookBookApp.ApplicationServices.Mappings
{
    public class UnitsProfile : Profile
    {
        public UnitsProfile()
        {
            this.CreateMap<DataAccess.Entities.Unit, API.Domain.Models.Unit>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ReverseMap();

            this.CreateMap<AddUnitRequest, DataAccess.Entities.Unit>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ReverseMap();

            this.CreateMap<DataAccess.Entities.Unit, UpdateUnitRequest>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ReverseMap();
        }
    }
}
