using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBookApp.ApplicationServices.Mappings
{
    public class ProductTypeProfile : Profile
    {
        public ProductTypeProfile()
        {
            this.CreateMap<DataAccess.Entities.ProductType, API.Domain.Models.ProductType>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ReverseMap();
        }
    }
}
