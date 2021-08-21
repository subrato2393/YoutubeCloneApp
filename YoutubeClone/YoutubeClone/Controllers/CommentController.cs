using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using YoutubeClone.Models;

namespace YoutubeClone.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
      
        [Authorize(Roles = "Member")]
        public IActionResult AddComment([FromBody] CommentsModel model)
        {
            model.AddCommentIntoDatabase(User.Identity.Name);
            return Json(model);
        }

        public IActionResult GetComments(Guid videoId)
        {
            CommentsModel model = new CommentsModel();
            model.GetAllComments(videoId, User.Identity.Name);
            return Json(model.CommentList);
        }

        public IActionResult GetCurrentComment(Guid videoId)
        {
            CommentsModel model = new CommentsModel();
            model.GetCurrentComment();
           // model.GetAllComments(model.VideoId, User.Identity.Name);
            return Json(model);
        }
    }
}
