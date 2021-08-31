using ChannelBO = YoutubeClone.Foundation.BusinessObjects.Channel;
using ChannelEO = YoutubeClone.Foundation.Entities.Channel;
using VideoBO = YoutubeClone.Foundation.BusinessObjects.Video;
using VideoEO = YoutubeClone.Foundation.Entities.Video;
using YoutubeClone.Foundation.UnitOfWorks;
using AutoMapper;
using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using Microsoft.Extensions.FileProviders;
using System.Linq;

namespace YoutubeClone.Foundation.Services
{
    public class ChannelService : IChannelService
    {
        private readonly IChannelUnitOfWork _channelUnitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ChannelService(IChannelUnitOfWork channelUnitOfWork,
            IWebHostEnvironment webHostEnvironment,
            IMapper mapper)
        {
            _channelUnitOfWork = channelUnitOfWork;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        public void AddChannelInfo(ChannelBO channelBo)
        {
            if (channelBo != null)
            {
                var channelEO = _mapper.Map<ChannelEO>(channelBo);

                _channelUnitOfWork.BeginTransaction();

                _channelUnitOfWork.ChannelRepository.Add(channelEO);

                _channelUnitOfWork.Commit();
            }
            else
            {
                throw new InvalidOperationException("Channel info must be provide");
            }
        }

        private void AddVideoInfoIntoDatabase(VideoBO videoBo)
        {
            if (videoBo != null)
            {
                var videoEo = _mapper.Map<VideoEO>(videoBo);

                _channelUnitOfWork.BeginTransaction();

                _channelUnitOfWork.VideoRepository.Add(videoEo);

                _channelUnitOfWork.Commit();
            }
            else
            {
                throw new InvalidOperationException("Channel info must be provide");
            }
        }

        public IList<ChannelBO> GetAllChannel()
        {
            var channelEoList = _channelUnitOfWork.ChannelRepository.GetAll();

            var channelBoList = _mapper.Map<IList<ChannelEO>, IList<ChannelBO>>(channelEoList);

            return channelBoList;
        }

        public IList<VideoBO> GetAllVideos()
        {
            List<VideoBO> videos = new List<VideoBO>();
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string path = Path.Combine("Video");

            var provider = new PhysicalFileProvider(_webHostEnvironment.WebRootPath);
            var contents = provider.GetDirectoryContents(path);
            var objFiles = contents.OrderBy(m => m.LastModified);

            foreach (var item in objFiles)
            {
                foreach (var dbVideo in GetVideos())
                {
                    if (item.Name == dbVideo.VideoName)
                    {
                        videos.Add(new VideoBO()
                        {
                            VideoName = item.Name,
                            VideoTitle = dbVideo.VideoTitle,
                            ChannelName = dbVideo.ChannelName,
                            Id = dbVideo.Id,
                            ViewCount=dbVideo.ViewCount
                        });
                    }
                }
            }

            return videos;
        }

        private IList<VideoBO> GetVideos()
        {
            var video = _channelUnitOfWork.VideoRepository.GetAll();
            var views = _channelUnitOfWork.ViewRepository.GetAll(); 

            var videoBo = (from v in video
                             join vi in views
                             on v.Id equals vi.Video.Id into viewGroup
                             from videoGroup in viewGroup.DefaultIfEmpty()
                                 // from rNull in r.DefaultIfEmpty()

                             group videoGroup by new { Id = v.Id,v.Channel.Name,v.Description,v.PublishDate,v.VideoTitle,v.VideoName } into g
                             let viewCount = g.Count(x => x != null)
                             select new VideoBO()
                             {
                                 ViewCount = viewCount,
                                 Id = g.Key.Id,
                                 ChannelName=g.Key.Name,
                                 Description=g.Key.Description,
                                 PublishDate=g.Key.PublishDate,
                                 VideoTitle=g.Key.VideoTitle,
                                 VideoName=g.Key.VideoName
                             }).ToList();

            // var videoViewBo = _mapper.Map<IList<VideoViewCount>>(videoView);


           // var VideoBoList = _mapper.Map<IList<VideoBO>>(video);
            return videoBo;
        }

        public ChannelBO GetChannelById(Guid channelId)
        {
            var channelEo = _channelUnitOfWork.ChannelRepository.GetById(channelId);
            var channelBo = _mapper.Map<ChannelBO>(channelEo);
            return channelBo;
        }

        public void UploadVideoToFolder(VideoBO video)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(video.VideoFile.FileName);
            string extension = Path.GetExtension(video.VideoFile.FileName);
            video.VideoName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/Video/", fileName);

            AddVideoInfoIntoDatabase(video);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                video.VideoFile.CopyTo(fileStream);
            }
        }

        public VideoBO GetVideoById(Guid id)
        {
            VideoBO video = new VideoBO();

            var videoEo = _channelUnitOfWork.VideoRepository.GetById(id);
            var videoBo = _mapper.Map<VideoBO>(videoEo);

            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string path = Path.Combine("Video");

            var provider = new PhysicalFileProvider(_webHostEnvironment.WebRootPath);
            var contents = provider.GetDirectoryContents(path);
            var objFiles = contents.OrderBy(m => m.LastModified);

            foreach (var item in objFiles)
            {
                if (item.Name == videoBo.VideoName)
                {
                    video.ChannelName = videoBo.ChannelName;
                    video.VideoName = videoBo.VideoName;
                    video.VideoTitle = videoBo.VideoTitle;
                    video.Description = videoBo.Description;
                    video.ChannelId = videoBo.ChannelId;
                    video.PublishDate = videoBo.PublishDate;
                    video.Id = videoBo.Id;
                };
            }

            return video;
        }
    }
}
