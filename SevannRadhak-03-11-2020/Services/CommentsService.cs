using Microsoft.Extensions.Configuration;
using SevannRadhak_03_11_2020.Interfaces;
using SevannRadhak_03_11_2020.Models;

namespace SevannRadhak_03_11_2020.Services
{
    public class CommentsService : RestfulService<CommentsEntity>, ICommentsService
    {
        public CommentsService(IConfiguration config) : base(config, "Apis:CommentsService")
        {
        }

        protected override string EndpointPrefix()
        {
            return $"?postId=";
        }
    }
}
