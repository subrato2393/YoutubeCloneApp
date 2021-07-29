using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using YoutubeClone.Models;

namespace YoutubeClone.Controllers
{
    [Authorize(Roles = "Member")]
    public class SubscriptionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
 
        public IActionResult Subscribe(Guid channelId,Guid videoId)
        {
            var model = new SubscribeModel();  
            var userName = User.Identity.Name;

            model.AddSubscriptionInfo(channelId,userName);

            return RedirectToAction("VideoStreaming", "Video", new { id = videoId});
        }
    }
}
