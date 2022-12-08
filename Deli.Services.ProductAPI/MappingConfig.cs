using AutoMapper;

using Deli.Services.ProductAPI.Models;
using Deli.Services.ProductAPI.Models.Dto;

namespace Deli.Services.ProductAPI
{
    public class MappingConfig
    {
        // We will create a method that will return the mapping configuration for auto mapper

        // public static so we can call that directly inside the "Program.cs"
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                // we want to convert/map ProductDto to Product and reverse
                // will map the properties as long as the names are the same otherwise will not touch
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();
            });

            // once we have the configuration we return "mappingConfig"
            return mappingConfig;
        }
    }
}
