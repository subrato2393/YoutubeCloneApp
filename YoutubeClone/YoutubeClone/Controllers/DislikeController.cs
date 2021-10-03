using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using YoutubeClone.Models;

namespace YoutubeClone.Controllers
{
    [Authorize(Roles ="Member")]
    public class DislikeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } 
        public IActionResult AddDisLike(Guid videoId)
        {
            var model = new DislikeModel();
            model.IsUserDislikedVideoBefore(videoId, User.Identity.Name);
            return Json(model);
        }
        public IActionResult GetDislike(Guid videoId) 
        {
            var model = new DislikeModel();
            model.GetVideoDisLikesCount(videoId);
            return Json(model);
        }
        public IActionResult DeleteDislike(Guid videoId)
        {
            var model = new DislikeModel();
            model.GetVideoDisLikesCount(videoId);
            return Json(model);
        }
    }
}
