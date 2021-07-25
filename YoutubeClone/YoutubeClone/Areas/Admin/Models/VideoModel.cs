using Autofac;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
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
        public  IFormFile VideoFile { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Publish Date")]
        public DateTime PublishDate { get; set; }


        private readonly IChannelService _channelService;
        public VideoModel(IChannelService channelService)
        {
            _channelService = channelService;
        }
        public VideoModel()
        {
            _channelService = Startup.AutofacContainer.Resolve<IChannelService>();
        }

        public async Task UploadVideoToFolder()
        {
            await _channelService.UploadVideoToFolder(new VideoBO()
            {
                VideoTitle = VideoTitle,
                VideoName = VideoFile.FileName,
                Description = Description,
                PublishDate = DateTime.Now,
                VideoFile = VideoFile
            });
        }

        public async Task AddVideoIntoDataBase()
        {
            await _channelService.AddVideoInfoIntoDatabase(new VideoBO()
            {
                VideoTitle = VideoTitle,
                VideoFile = VideoFile,
                VideoName = VideoFile.FileName,
                Description = Description,
                PublishDate = DateTime.Now,
            });
        }
    }
}
