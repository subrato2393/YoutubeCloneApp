using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoutubeClone.Models;

namespace YoutubeClone.Controllers
{
    public class CommentsReplyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } 

        public IActionResult AddCommentsReply([FromBody] CommentsReplyModel model)
        {
            model.AddCommentsReplyIntoDatabase(User.Identity.Name);
            return Json(model);
        }
    }
}

