using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.UserRoles;

namespace CookBookApp.ApplicationServices.Mappings
{
    public class UserRolesProfile : Profile
    {
        public UserRolesProfile()
        {
            this.CreateMap<DataAccess.Entities.UserRole, API.Domain.Models.UserRole>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Role, y => y.MapFrom(z => z.Name))
                .ReverseMap();

            this.CreateMap<AddUserRolesRequest, DataAccess.Entities.UserRole>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ReverseMap();

        }
    }
}
