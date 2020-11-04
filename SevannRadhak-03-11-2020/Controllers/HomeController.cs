using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SevannRadhak_03_11_2020.Interfaces;
using SevannRadhak_03_11_2020.Models;

namespace SevannRadhak_03_11_2020.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAlbumsService _albumsService;
        private readonly ICommentsService _commentsService;
        private readonly IPhotosService _photosService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(
            IAlbumsService albumsService,
            ICommentsService commentsService,
            IPhotosService photosService,
            ILogger<HomeController> logger)
        {
            _albumsService = albumsService;
            _commentsService = commentsService;
            _photosService = photosService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            ICollection<AlbumEntity> albums = await _albumsService.GetAllAsync();
            ICollection<PhotoEntity> photos = new List<PhotoEntity>();
            ICollection<CommentsEntity> comments = new List<CommentsEntity>();

            return View(new GenericModelView { Albums = albums, Comments = comments, Photos = photos });
        }

        //[HttpGet("GetCommentsByPhotoPruebaAsync/{id}")]
        //public async Task<IActionResult> GetCommentsByPhotoPruebaAsync(int id)
        //{
        //    try
        //    {
        //        return View(nameof(Index), await _commentsService.GetManyAsync(id));
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}



        //[HttpGet("GetCommentsByPhotoAsync/{id}")]
        //public async Task<ICollection<CommentsEntity>> GetCommentsByPhotoAsync(int id)
        //{
        //    return await _commentsService.GetManyAsync(id);
        //}

        //[HttpPost]
        //[Route("PhotosByAlbumAsync")]
        //public async Task<ICollection<PhotoEntity>> PhotosByAlbumAsync()
        //{
        //    try
        //    {
        //        return await _photosService.GetManyAsync(1);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        [HttpGet]
        [Route("CommentsByPhotoId")]
        public async Task<ICollection<CommentsEntity>> CommentsByPhotoId(int id)
        {
            try
            {
                return await _commentsService.GetManyAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpGet]
        [Route("PhotosByAlbumId")]
        public async Task<ICollection<PhotoEntity>> PhotosByAlbumId(int id)
        {
            try
            {
                return await _photosService.GetManyAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
