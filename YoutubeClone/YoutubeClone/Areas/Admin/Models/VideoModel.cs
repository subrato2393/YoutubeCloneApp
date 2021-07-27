using Autofac;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using YoutubeClone.Foundation.Services;
using VideoBO = YoutubeClone.Foundation.BusinessObjects.Video;

namespace YoutubeClone.Areas.Admin.Models
{
    public class VideoModel
    {
        [Required]
        [Display(Name = "Video Title")]
        public string VideoTitle { get; set; }

        [Required]
        [Display(Name = "Video Name")]
        public string VideoName { get; set; }

        public IFormFile VideoFile { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Publish Date")]
        public DateTime PublishDate { get; set; }
        public List<SelectListItem> Channels { get; set; }
        public Guid ChannelId { get; set; }


        private readonly IChannelService _channelService;
        public VideoModel(IChannelService channelService)
        {
            _channelService = channelService;
        }
        public VideoModel()
        {
            _channelService = Startup.AutofacContainer.Resolve<IChannelService>();
        }
        public void UploadVideo()
        {
            var channel = _channelService.GetChannelById(ChannelId);

            _channelService.UploadVideoToFolder(new VideoBO()
            {
                VideoTitle = VideoTitle,
                VideoName = VideoFile.FileName,
                Description = Description,
                PublishDate = DateTime.Now,
                VideoFile = VideoFile,
                ChannelId = ChannelId,
                Channel = channel
            });
        }

        public void GetAllChannel()
        {
            var channelList = _channelService.GetAllChannel();

            var channels = (from t in channelList
                            select new SelectListItem
                            {
                                Value = t.Id.ToString(),
                                Text = t.Name,
                            }).ToList();

            Channels = channels;
        }
    }
}
