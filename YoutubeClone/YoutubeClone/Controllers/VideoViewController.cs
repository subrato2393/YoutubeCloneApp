using Microsoft.AspNetCore.Mvc;
using System;
using YoutubeClone.Models;

namespace YoutubeClone.Controllers
{
    public class VideoViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddVideoView(Guid videoId)
        {
            var model = new ViewCountModel();
            model.AddVideoViewInformation(videoId);

            return View();
        }
    }
}
