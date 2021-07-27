using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using YoutubeClone.Models;

namespace YoutubeClone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                var model = new HomeModel();
                var videos = model.GetVideoList();
                return View(videos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to get Video list");
            }
            return View();
        }

        public IActionResult VideoStreaming(Guid id)
        {
            var model = new HomeModel();
            var video= model.GetVideoById(id);
            return View(video);
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
