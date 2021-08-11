using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Text.Json;
using YoutubeClone.Foundation.Entities;
using YoutubeClone.Models;

namespace YoutubeClone.Controllers
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddComment([FromBody] CommentsModel model)
        {
            //return Json(new { redirectToAction = Url.Action("VideoStreaming", "Video", new { Id = model.VideoId }) });
            return RedirectToAction("VideoStreaming", "Video", new { Id = model.VideoId });
        }
    }
}
