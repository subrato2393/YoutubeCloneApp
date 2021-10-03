using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using YoutubeClone.Areas.Admin.Models;

namespace YoutubeClone.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize(Roles ="Admin")]
    public class AnalyticsController : Controller
    {
        public IActionResult GetVideoViewChart() 
        {
            var model = new ChartModel();
            model.GetAllChannel();
            model.GetVideoViewCountSpecificDate(model.ChannelId);
            
            return View(model);
        }
         
        [HttpPost]
        public IActionResult GetVideoViewChart(ChartModel model)
        {
            model.GetAllChannel();
            model.GetVideoViewCountSpecificDate(model.ChannelId);
            return View(model);
        }
    }
}
