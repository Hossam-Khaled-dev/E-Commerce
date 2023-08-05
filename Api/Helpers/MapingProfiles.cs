using Api.DTOs;
using AutoMapper;
using Core.Entites;

namespace Api.Helpers
{
    public class MapingProfiles : Profile
    {
        public MapingProfiles()
        {

            CreateMap<Product, ProductDTO>()
                .ForMember(d => d.ProductBrand, o => o.MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.ProductType, o => o.MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());

        }
    }
}
