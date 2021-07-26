using ChannelBO = YoutubeClone.Foundation.BusinessObjects.Channel;
using ChannelEO = YoutubeClone.Foundation.Entities.Channel;
using VideoBO = YoutubeClone.Foundation.BusinessObjects.Video;
using VideoEO = YoutubeClone.Foundation.Entities.Video;
using YoutubeClone.Foundation.UnitOfWorks;
using AutoMapper;
using System;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;

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
        public void AddVideoInfoIntoDatabase(VideoBO videoBo)
        {
            if (videoBo != null)
            {
                _channelUnitOfWork.BeginTransaction();

                var videoEo = _mapper.Map<VideoEO>(videoBo);

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

        public void UploadVideoToFolder(VideoBO video)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(video.VideoFile.FileName);
            string extension = Path.GetExtension(video.VideoFile.FileName);
            video.VideoName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwRootPath + "/Video/", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            
                 video.VideoFile.CopyToAsync(fileStream);
            }
        }
    }
