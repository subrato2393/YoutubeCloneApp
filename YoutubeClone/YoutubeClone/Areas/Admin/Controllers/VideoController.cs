using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using YoutubeClone.Areas.Admin.Models;

namespace YoutubeClone.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "Admin")]
    public class VideoController : Controller
    {
        private readonly ILogger<VideoController> _logger;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UploadVideo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        public async Task<IActionResult> UploadVideo(VideoModel model)
        {
            try
            {
                ModelState.Remove("VideoName");
                if (ModelState.IsValid)
                {
                    await model.UploadVideoToFolder();

                    await model.AddVideoIntoDataBase();

                    return RedirectToAction("Index", "Home");
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
