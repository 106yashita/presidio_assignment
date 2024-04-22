using ModelClassLib;
using StoreDALLibrary;
using System.Data;

namespace StoreBLLibrary
{
    public class VideoBL : IVideoService
    {
        readonly IRepository<int, Video> _videoRepository;
        public VideoBL()
        {
            _videoRepository = new VideoRepository();
        }
        public int AddVideo(Video video)
        {
            Video result = _videoRepository.Add(video);

            if (result != null)
            {
                return result.VideoId;
            }
            throw new DuplicateVideoException();
        }

        public List<Video> GetAllVideos()
        {
            return _videoRepository.GetAll();
        }

        public Video GetVideoById(int id)
        {
            Video video = _videoRepository.Get(id);
            if (video != null)
            {
                return video;
            }
            throw new VideoNotExistException();
        }

        public List<Video> GetVideosByGenre(string genre)
        {
            List<Video> videoGenre = new List<Video>();
            List<Video> videos = _videoRepository.GetAll();
            foreach (Video video in videos)
            {
                if (video.Genre == genre)
                {
                    videoGenre.Add(video);
                }
            }
            return videoGenre;
        }

        public Video RemoveVideo(int id)
        {
            Video video = _videoRepository.Delete(id);
            if (video != null)
            { return video; }
            throw new VideoNotExistException();
        }

        public List<Video> SearchAvailableVideos()
        {
            List<Video> videoAvailable = new List<Video>();
            List<Video> videos = _videoRepository.GetAll();
            foreach (Video video in videos)
            {
                if (video.AvailabilityStatus == true)
                {
                    videoAvailable.Add(video);
                }
            }
            return videoAvailable;
        }

        public void UpdateAvailabilityStatus(int videoId)
        {
            Video video = _videoRepository.Get(videoId);
            if (video != null)
            {
                video.UpdateStatus();
            }
            throw new VideoNotExistException();
        }

        public void UpdateRentalPrice(int id, int price)
        {
            Video video = _videoRepository.Get(id);
            if (video != null)
            {
                video.RentalPrice = price;
            }
            throw new VideoNotExistException();
        }

        public Video UpdateVideo(int videoId, Video updatedVideo)
        {
            Video video = _videoRepository.Get(videoId);
            if (video != null)
            {
                video = _videoRepository.Update(updatedVideo);
            }
            throw new VideoNotExistException();
        }
    }
}
