using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using YoutubeClone.Areas.Admin.Models;

namespace YoutubeClone.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "Admin")]
    public class ChannelController : Controller
    {
        private readonly ILogger<ChannelController> _logger;

        public ChannelController(ILogger<ChannelController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new ChannelModel();
            return View(model);
        }

        public IActionResult CreateChannel()
        {
            return View();
        } 

        [HttpPost] 
        public IActionResult CreateChannel(ChannelModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.AddChannelInformation();
                    
                    return RedirectToAction("Index");
                }

                else
                {
                    return View();
                }
              
            }

            catch (Exception exception)
            {
                _logger.LogError(exception, "Failed to create channel");
               
                return View();
            }
        }
    }
}
