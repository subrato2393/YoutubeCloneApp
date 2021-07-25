using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using YoutubeClone.Areas.Admin.Models;

namespace YoutubeClone.Areas.Admin.Controllers
{
    [Area("Admin"), Authorize(Roles = "Admin")]
    public class VideoController : Controller
    {
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
            if (ModelState.IsValid)
            {
                await model.UploadVideoToFolder();

                await model.AddVideoIntoDataBase();

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
