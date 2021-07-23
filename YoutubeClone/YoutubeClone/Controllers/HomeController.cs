using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles ="Member")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles ="Member")]
        public IActionResult Create(ChannelModel model) 
        {
            try
            {
                model.AddChannelInformation(model);
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "error");
                return View();
            }
        }
        public IActionResult Index()
        {
            return View();
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
