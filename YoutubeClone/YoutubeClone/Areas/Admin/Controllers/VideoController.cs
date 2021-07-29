using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using YoutubeClone.Areas.Admin.Models;

namespace YoutubeClone.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "Admin")]
    public class VideoController : Controller
    {
        private readonly ILogger<VideoController> _logger;
        public VideoController(ILogger<VideoController> logger)
        {
            _logger = logger;
        }
        public IActionResult ShowAllVideo()
        {
            return View(); 
        }

        public IActionResult UploadVideo()
        {
            var model = new VideoModel();
            model.GetAllChannel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        public IActionResult UploadVideo(VideoModel model)
        {
            try
            {
                ModelState.Remove("VideoName");
                if (ModelState.IsValid)
                {
                    model.GetAllChannel();
                    
                    model.UploadVideo();

                    return RedirectToAction("ShowAllVideo");
                }
            }

            catch (Exception ex)
            {
                _logger.LogError(ex,"Failed To Upload Video");
            }
           
            return View(model);
        }
    }
}
