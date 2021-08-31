using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoutubeClone.Foundation.BusinessObjects;
using YoutubeClone.Foundation.Entities;
using YoutubeClone.Foundation.UnitOfWorks;
using YoutubeClone.Membership.Entities;
using Subscriber = YoutubeClone.Foundation.Entities.Subscriber;
using LikeBO = YoutubeClone.Foundation.BusinessObjects.Likes;
using LikeEO = YoutubeClone.Foundation.Entities.Likes;
using DislikeBO = YoutubeClone.Foundation.BusinessObjects.Dislikes;
using DislikeEO = YoutubeClone.Foundation.Entities.Dislikes;
using CommentBO = YoutubeClone.Foundation.BusinessObjects.Comments;
using CommentEO = YoutubeClone.Foundation.Entities.Comments;
using CommentsLikeBO = YoutubeClone.Foundation.BusinessObjects.CommentsLike;
using CommentsLikeEO = YoutubeClone.Foundation.Entities.CommentsLike;
using CommentsReplyEO = YoutubeClone.Foundation.Entities.CommentsReply;
using CommentsReplyBO = YoutubeClone.Foundation.BusinessObjects.CommentsReplyBO;

namespace YoutubeClone.Foundation.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IChannelUnitOfWork _channelUnitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private Guid _commentId;
        private Guid _commentReplyId;

        public FeedbackService(IChannelUnitOfWork channelUnitOfWork,
            UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {
            _userManager = userManager;
            _channelUnitOfWork = channelUnitOfWork;
            _mapper = mapper;
        }

        public bool IsUserSubscribeBefore(Guid channelId, string userName)
        {
            var subscribers = _channelUnitOfWork.SubscriberRepository.GetAll();
            var subscribeUsers = subscribers.Where(x => x.Channel.Id == channelId && x.ApplicationUser.Email == userName).ToList();

            return subscribeUsers.Count > 0;
        }

        public async Task AddSubscriptionIntoDatabase(Guid channelId, string userName)
        {
            var channel = _channelUnitOfWork.ChannelRepository.GetById(channelId);
            var user = await _userManager.FindByEmailAsync(userName);

            var subscriber = new Subscriber()
            {
                ApplicationUser = user,
                Channel = channel
            };

            _channelUnitOfWork.BeginTransaction();
            _channelUnitOfWork.SubscriberRepository.Add(subscriber);
            _channelUnitOfWork.Commit();
        }

        public void AddVideoViewCountInfo(VideoViewCount videoViewCount)
        {
            var viewsEntity = _mapper.Map<Views>(videoViewCount);

            _channelUnitOfWork.BeginTransaction();
            _channelUnitOfWork.ViewRepository.Add(viewsEntity);
            _channelUnitOfWork.Commit();
        }

        public int GetVideoViewCountFromDatabase(Guid id)
        {
            var views = _channelUnitOfWork.ViewRepository.GetAll();
            var count = views.Where(x => x.Video.Id == id).Count();
            return count;
        }

        public IList<VideoViewCount> GetAllVideoView()
        {
            var views = _channelUnitOfWork.ViewRepository.GetAll();
            var video = _channelUnitOfWork.VideoRepository.GetAll();
             
            var videoView = (from v in video 
                           join vi in views
                           on v.Id equals vi.Video.Id into viewGroup
                           from videoGroup in viewGroup.DefaultIfEmpty()
                               // from rNull in r.DefaultIfEmpty()

                           group videoGroup by new { Id = v.Id,} into g
                           let viewCount = g.Count(x => x != null)
                           select new VideoViewCount()
                           {
                               ViewCount = viewCount,
                               Id = g.Key.Id,
                           }).ToList();

            // var videoViewBo = _mapper.Map<IList<VideoViewCount>>(videoView);

            return videoView;
        }

        public int GetAllSubscriberCount(Guid channelId)
        {
            var subscribers = _channelUnitOfWork.SubscriberRepository.GetAll();
            var count = subscribers.Where(x => x.Channel.Id == channelId).Count();
            return count;
        }

        public IList<VideoViewChart> GetVideoViewCountonDateForChart(Guid channelId)
        {
            var channels = _channelUnitOfWork.ChannelRepository.GetAll();
            var video = _channelUnitOfWork.VideoRepository.GetAll();
            var view = _channelUnitOfWork.ViewRepository.GetAll();

            DateTime today = DateTime.Today;

            var videoViewCount = (from v in view
                                  join vid in video on v.Video.Id equals vid.Id
                                  join chnl in channels on vid.Channel.Id equals chnl.Id
                                  where chnl.Id == channelId && v.ViewDate.Month == today.Month && v.ViewDate.Year == today.Year
                                  group new { v, chnl } by new { v.ViewDate, chnl.Id, chnl.Name } into vg
                                  select new VideoViewChart
                                  {
                                      ChannelName = vg.Key.Name,
                                      ViewDate = vg.Key.ViewDate,
                                      ViewCount = vg.Count()
                                  }).OrderBy(x => x.ViewDate).ToList();
            return videoViewCount;
        }

        public async Task AddVideoLike(LikeBO likeBO)
        {
            var user = await _userManager.FindByNameAsync(likeBO.UserName);

            var video = _channelUnitOfWork.VideoRepository.GetById(likeBO.VideoId);

            var like = new LikeEO
            {
                LikesCount = likeBO.LikesCount,
                Video = video,
                User = user
            };

            _channelUnitOfWork.BeginTransaction();
            _channelUnitOfWork.LikeRepository.Add(like);
            _channelUnitOfWork.Commit();
        }
        public int GetLikesCount(Guid id)
        {
            var likes = _channelUnitOfWork.LikeRepository.GetAll();
            var count = likes.Where(x => x.Video.Id == id).Count();
            return count;
        }
        public bool IsLiked(Guid videoId, string name)
        {
            var likes = _channelUnitOfWork.LikeRepository.GetAll();
            var IsLiked = likes.Where(x => x.Video.Id == videoId && x.User.UserName == name).ToList();

            return IsLiked.Count > 0;
        }

        public void DeleteLike(Guid videoId, string name)
        {
            var likes = _channelUnitOfWork.LikeRepository.GetAll();
            var like = likes.FirstOrDefault(x => x.Video.Id == videoId && x.User.UserName == name);

            _channelUnitOfWork.BeginTransaction();
            _channelUnitOfWork.LikeRepository.Remove(like);
            _channelUnitOfWork.Commit();
        }

        public bool IsDisliked(Guid videoId, string name)
        {
            var dislikes = _channelUnitOfWork.DislikeRepository.GetAll();
            var IsDisliked = dislikes.Where(x => x.Video.Id == videoId && x.User.UserName == name).ToList();

            return IsDisliked.Count > 0;
        }

        public void DeleteDislike(Guid videoId, string name)
        {
            var dislikes = _channelUnitOfWork.DislikeRepository.GetAll();
            var dislike = dislikes.FirstOrDefault(x => x.Video.Id == videoId && x.User.UserName == name);

            _channelUnitOfWork.BeginTransaction();
            _channelUnitOfWork.DislikeRepository.Remove(dislike);
            _channelUnitOfWork.Commit();
        }

        public async Task AddVideoDislike(DislikeBO dislikeBO)
        {
            var user = await _userManager.FindByNameAsync(dislikeBO.UserName);

            var video = _channelUnitOfWork.VideoRepository.GetById(dislikeBO.VideoId);

            var dislike = new DislikeEO
            {
                DislikesCounts = dislikeBO.DislikesCount,
                Video = video,
                User = user
            };

            _channelUnitOfWork.BeginTransaction();
            _channelUnitOfWork.DislikeRepository.Add(dislike);
            _channelUnitOfWork.Commit();
        }

        public int GetDislikesCount(Guid id)
        {
            var dislikes = _channelUnitOfWork.DislikeRepository.GetAll();
            var count = dislikes.Where(x => x.Video.Id == id).Count();
            return count;
        }

        public async Task AddComments(CommentBO commentBo)
        {
            var user = await _userManager.FindByNameAsync(commentBo.UserName);
            var video = _channelUnitOfWork.VideoRepository.GetById(commentBo.VideoId);

            var comment = new CommentEO()
            {
                Description = commentBo.Description,
                Id = commentBo.Id,
                Video = video,
                User = user
            };

            _channelUnitOfWork.BeginTransaction();
            _channelUnitOfWork.CommentRepository.Add(comment);
            _channelUnitOfWork.Commit();
            _commentId = comment.Id;
        }

        public IList<CommentBO> GetAllComments(Guid id, string name)
        {
            var comments = _channelUnitOfWork.CommentRepository.GetAll();
            var commentsLike = _channelUnitOfWork.CommentLikeRepository.GetAll();
            var commentsReply = _channelUnitOfWork.CommentReplyRepository.GetAll();

            var comment = (from c in comments
                           join cl in commentsLike
                           on c.Id equals cl.Comments.Id into f
                           join cr in commentsReply
                           on c.Id equals cr.Comments.Id
                           from fNull in f.DefaultIfEmpty()
                          // from rNull in r.DefaultIfEmpty()

                           group  fNull by new { Id = c.Id, c.Description, c.User.UserName, VideoId = c.Video.Id, CommentReplyDescription = cr.Description } into g
                           let fCount = g.Count(x => x != null)
                           select new CommentBO()
                           {
                               Description = g.Key.Description,
                               LikeCount = fCount,
                               Id = g.Key.Id,
                               UserName = g.Key.UserName,
                               VideoId = g.Key.VideoId,
                               CommentReplyDescription = g.Key.CommentReplyDescription
                           }).ToList();

            var filterComment = comment.Where(x => x.VideoId == id);
            var commentsBo = _mapper.Map<IList<CommentBO>>(filterComment);
            return commentsBo;
        }

        public CommentBO GetComment()
        {
            var comment = _channelUnitOfWork.CommentRepository.GetById(_commentId);

            var commentBo = _mapper.Map<CommentBO>(comment);
            return commentBo;
        }

        public async Task AddCommetsLike(CommentsLikeBO commentsLike)
        {
            var user = await _userManager.FindByNameAsync(commentsLike.UserName);

            var comment = _channelUnitOfWork.CommentRepository.GetById(commentsLike.CommentId);

            var commentLike = new CommentsLikeEO
            {
                LikesCount = commentsLike.LikesCount,
                Comments = comment,
                User = user
            };

            _channelUnitOfWork.BeginTransaction();
            _channelUnitOfWork.CommentLikeRepository.Add(commentLike);
            _channelUnitOfWork.Commit();
        }

        public bool IsCommentDisliked(Guid commentId, string name)
        {
            //var dislikes = _channelUnitOfWork.DislikeRepository.GetAll();
            //var IsDisliked = dislikes.Where(x => x.Video.Id == videoId && x.User.UserName == name).ToList();

            return true;
        }

        public bool IsCommentLiked(Guid commentId, string name)
        {
            var likes = _channelUnitOfWork.CommentLikeRepository.GetAll();
            var IsLiked = likes.Where(x => x.Comments.Id == commentId && x.User.UserName == name).ToList();

            return IsLiked.Count > 0;
        }

        public void DeleteCommentLike(Guid commentId, string name)
        {
            var likes = _channelUnitOfWork.CommentLikeRepository.GetAll();
            var like = likes.FirstOrDefault(x => x.Comments.Id == commentId && x.User.UserName == name);

            _channelUnitOfWork.BeginTransaction();
            _channelUnitOfWork.CommentLikeRepository.Remove(like);
            _channelUnitOfWork.Commit();
        }

        public int GetCommentsLikesCount(Guid commentId)
        {
            var likes = _channelUnitOfWork.CommentLikeRepository.GetAll();
            var count = likes.Where(x => x.Comments.Id == commentId).Count();
            return count;
        }

        public async Task AddCommentsReply(CommentsReplyBO commentsReplyBO)
        {
            var user = await _userManager.FindByNameAsync(commentsReplyBO.UserName);

            var commentReply = _channelUnitOfWork.CommentRepository.GetById(commentsReplyBO.CommentId);

            var commentReplyEo = new CommentsReplyEO
            {
                Id = commentsReplyBO.Id,
                Description = commentsReplyBO.Description,
                Comments = commentReply,
                User = user
            };

            _channelUnitOfWork.BeginTransaction();
            _channelUnitOfWork.CommentReplyRepository.Add(commentReplyEo);
            _channelUnitOfWork.Commit();
            _commentReplyId = commentReplyEo.Id;
        }

        public CommentsReplyBO GetCurrentCommentReply()
        {
            var commentReplyEo = _channelUnitOfWork.CommentReplyRepository.GetById(_commentReplyId);
            var commentReplyBo = _mapper.Map<CommentsReplyBO>(commentReplyEo);
            return commentReplyBo;
        }
    }
}
