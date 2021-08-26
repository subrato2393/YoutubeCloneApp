using Microsoft.AspNetCore.Mvc;
using System;
using YoutubeClone.Models;

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
            var model = new CommentsLikeModel();
            model.IsUserLikedCommentBefore(commentId, User.Identity.Name);
            return Json(model); 
        }
        
        public IActionResult GetCommentLike(Guid commentId)
        {
            var model = new CommentsLikeModel();
            model.GetCommentLikeCount(commentId);
          //  model.IsUserLikedBefore(commentId , User.Identity.Name);
            return Json(model);
        }

        //public IActionResult GetAllCommentsLike(Guid commentId)
        //{
        //    var model = new CommentsLikeModel();
        //   // model.GetAllCommentLike
        //    //model.
        //    return Json("");
        //}
    }
}
