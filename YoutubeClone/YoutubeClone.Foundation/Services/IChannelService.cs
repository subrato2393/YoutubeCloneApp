using System.Threading.Tasks;
using ChannelBO = YoutubeClone.Foundation.BusinessObjects.Channel;
using VideoBO = YoutubeClone.Foundation.BusinessObjects.Video;

namespace YoutubeClone.Foundation.Services
{
    public interface IChannelService
    {
        void AddChannelInfo(ChannelBO channel);
        Task AddVideoInfoIntoDatabase(VideoBO video);
        Task UploadVideoToFolder(VideoBO video);
    }
}