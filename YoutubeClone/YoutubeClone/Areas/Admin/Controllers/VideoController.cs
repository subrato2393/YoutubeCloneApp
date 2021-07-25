using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YoutubeClone.Foundation.Entities;
using YoutubeClone.Foundation.Services;

namespace YoutubeClone.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VideoController : Controller
    {
        private readonly IChannelService _channelService;
        private IWebHostEnvironment _webHostEnvironment;

        public VideoController(IWebHostEnvironment webHostEnvironment,IChannelService channelService)
        {
            _webHostEnvironment = webHostEnvironment;
            _channelService = channelService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public  IActionResult UploadVideo()
        {
            return View();
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        public async Task<IActionResult> UploadVideo(Video video)
        {
            if (ModelState.IsValid)
            {
                //Upload Video To folder
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(video.VideoFile.FileName);
                string extension = Path.GetExtension(video.VideoFile.FileName);
                video.VideoName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Video/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await video.VideoFile.CopyToAsync(fileStream);
                }

                //Insert into Database
                _channelService.AddVideoInfoIntoDatabase(video);
               
                return RedirectToAction("Index","Home");
            }
            return View(video);
        }
    }
}
