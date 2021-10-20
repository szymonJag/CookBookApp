using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain.Users;

namespace CookBookApp.ApplicationServices.Mappings
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            this.CreateMap<DataAccess.Entities.User, API.Domain.Models.User>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.UserName, y => y.MapFrom(z => z.Username))
                .ForMember(x => x.Role, y => y.MapFrom(z => z.UserRole.Name))
                .ForMember(x => x.HashedPassword, y => y.MapFrom(z => z.HashedPassword))
                .ReverseMap();

            this.CreateMap<AddUserRequest, DataAccess.Entities.User>()
                .ForMember(x => x.Username, y => y.MapFrom(z => z.UserName))
                .ForMember(x => x.HashedPassword, y => y.MapFrom(z => z.Password))
                .ReverseMap();

        }
    }
}
