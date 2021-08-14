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
            return RedirectToAction("VideoStreaming", "Video", new { Id = model.VideoId });
        }
    }
}
