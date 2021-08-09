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

            return Json(new { redirectToAction = Url.Action("VideoStreaming", "Video", new { Id = videoId }) });
        }
    }
}
