using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YoutubeClone.Models;

namespace YoutubeClone.Controllers
{
    [Authorize(Roles ="Member")]
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddComment([FromBody] CommentsModel model)
        {
            model.AddCommentIntoDatabase(User.Identity.Name);
            return Json(model);
        }
        public IActionResult GetAllComments([FromBody] CommentsModel model)
        {
            model.GetAllComments(model.VideoId, User.Identity.Name);
            return Json(model.CommentList);
        }
    }
}
