using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using YoutubeClone.Models;

namespace YoutubeClone.Controllers
{
    [Authorize(Roles = "Member")]
    public class LikeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddLike(Guid videoId)
        { 
            var model = new LikeModel();
            model.IsUserLikedVideoBefore(videoId, User.Identity.Name);
            return Json(model);
        }
        public IActionResult GetLike(Guid videoId)
        {
            var model = new LikeModel();
            model.GetVideoLikesCount(videoId);
            return Json(model);
        }
    }
}
