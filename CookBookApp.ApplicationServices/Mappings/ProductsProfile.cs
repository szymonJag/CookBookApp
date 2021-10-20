using AutoMapper;
using CookBookApp.ApplicationServices.API.Domain;
using CookBookApp.ApplicationServices.API.Domain.Products;

namespace CookBookApp.ApplicationServices.Mappings
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            this.CreateMap<DataAccess.Entities.Product, API.Domain.Models.Product>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Kcal, y => y.MapFrom(z => z.Kcal))
                .ForMember(x => x.IsAcceptedByAdmin, y => y.MapFrom(z => z.IsAcceptedByAdmin))
                .ForMember(x => x.ProductType, y => y.MapFrom(z => z.ProductType.Name))
                .ReverseMap();

            this.CreateMap<AddProductRequest, DataAccess.Entities.Product>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Kcal, y => y.MapFrom(z => z.Kcal))
                .ReverseMap();

            this.CreateMap<DataAccess.Entities.Product, UpdateProductRequest>()
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
                .ForMember(x => x.Kcal, y => y.MapFrom(z => z.Kcal))
                .ReverseMap();
        }
    }
}
