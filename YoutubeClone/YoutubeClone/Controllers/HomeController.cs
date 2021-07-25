using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using YoutubeClone.Foundation.Entities;
using YoutubeClone.Models;

namespace YoutubeClone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IWebHostEnvironment _webHostEnvironment;
        public HomeController(ILogger<HomeController> logger,IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Video> videos = new List<Video>();
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string path = Path.Combine("Video");

            var provider = new PhysicalFileProvider(_webHostEnvironment.WebRootPath);
            var contents = provider.GetDirectoryContents(path);
            var objFiles = contents.OrderBy(m => m.LastModified);

            foreach (var item in objFiles)
            {
                videos.Add(new Video() { VideoName = item.Name });
            }

            return View(videos);
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
