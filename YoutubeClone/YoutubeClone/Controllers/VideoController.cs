using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using YoutubeClone.Models;

namespace YoutubeClone.Controllers
{
    public class VideoController : Controller
    {
        private readonly ILogger<VideoController> _logger;

        public VideoController(ILogger<VideoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                var model = new VideoListModel();
                model.GetVideoList();
                model.GetVideoViewCount();

                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get Video list");
            }
            return View();
        }
         
        public IActionResult VideoStreaming(Guid id)
        {
            var model = new VideoViewModel();
            model.GetVideoById(id,User.Identity.Name);
            model.GetVideoViewCount(id);

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
