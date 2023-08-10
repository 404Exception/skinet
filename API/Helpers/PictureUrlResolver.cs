using API.ReturnDto;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class PictureUrlResolver : IValueResolver<Product,
        ProductToReturnDto, string>
    {
        private readonly IConfiguration _config;

        public PictureUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Product source, ProductToReturnDto destination, 
            string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiUrl"] + source.PictureUrl;
            }
#pragma warning disable CS8603 // Possible null reference return.
            return null;
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
