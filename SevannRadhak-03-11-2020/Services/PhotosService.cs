using Microsoft.Extensions.Configuration;
using SevannRadhak_03_11_2020.Interfaces;
using SevannRadhak_03_11_2020.Models;

namespace SevannRadhak_03_11_2020.Services
{
    public class PhotosService : RestfulService<PhotoEntity>, IPhotosService
    {
        public PhotosService(IConfiguration config) : base(config, "Apis:PhotosService")
        {
        }

        protected override string EndpointPrefix()
        {
            return $"?albumId=";
        }
    }
}
