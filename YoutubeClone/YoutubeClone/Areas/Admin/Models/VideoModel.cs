using Autofac;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using YoutubeClone.Foundation.Services;
using VideoBO = YoutubeClone.Foundation.BusinessObjects.Video;

namespace YoutubeClone.Areas.Admin.Models
{
    public class VideoModel
    {
        public virtual Guid Id { get; set; }
        public virtual string VideoTitle { get; set; }
        public virtual string VideoName { get; set; }
        public virtual IFormFile VideoFile { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime PublishDate { get; set; }


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
                PublishDate = PublishDate,
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
                PublishDate = PublishDate,
            });
        }
    }
}
