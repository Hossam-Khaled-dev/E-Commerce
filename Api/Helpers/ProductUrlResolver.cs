using Api.DTOs;
using AutoMapper;
using Core.Entites;

namespace Api.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductDTO, string>
    {

        private readonly IConfiguration _Config;

        public ProductUrlResolver(IConfiguration config)
        {
            _Config = config;
        }

        public string Resolve(Product source, ProductDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _Config["ApiUrl"] + source.PictureUrl;


            }
            else
            {
                return null;
            }
        }
    }
}
