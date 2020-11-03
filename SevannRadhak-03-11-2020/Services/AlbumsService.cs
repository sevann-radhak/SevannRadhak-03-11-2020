using Microsoft.Extensions.Configuration;
using SevannRadhak_03_11_2020.Interfaces;
using SevannRadhak_03_11_2020.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SevannRadhak_03_11_2020.Services
{
    public class AlbumsService : RestfulService<AlbumEntity>, IAlbumsService
    {
        public AlbumsService(IConfiguration config) : base(config, "Apis:AlbumsService")
        {
        }

        protected override string EndpointPrefix()
        {
            return $"?userId=";
        }
    }
}
