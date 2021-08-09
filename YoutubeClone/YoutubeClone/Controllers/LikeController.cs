using Microsoft.AspNetCore.Mvc;
using System;
using YoutubeClone.Models;

namespace YoutubeClone.Controllers
{
    public class LikeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddLike(Guid videoId)
        { 
            var model = new LikeModel();
            model.AddLikeInfo(videoId);

            return Json(new { redirectToAction = Url.Action("VideoStreaming", "Video",new { Id=videoId})});
        }
    }
}
