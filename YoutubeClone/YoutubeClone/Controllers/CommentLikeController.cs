using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YoutubeClone.Controllers
{
    public class CommentLikeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddCommentsLike(Guid commentId)
        {
            //var model = new LikeModel(); 
            //model.IsUserLikedVideoBefore(videoId, User.Identity.Name);
            //return Json(model);
            return Json("");
        }
    }
}
