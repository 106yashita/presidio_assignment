using ModelClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBLLibrary
{
    public interface IVideoService
    {
        int AddVideo(Video video);
        Video RemoveVideo(int id);
        Video GetVideoById(int id);
        Video UpdateVideo(int videoId, Video updatedVideo);
        List<Video> GetAllVideos();
        List<Video> GetVideosByGenre(string genre);
        List<Video> SearchAvailableVideos();
        void UpdateAvailabilityStatus(int videoId);
        void UpdateRentalPrice(int id, int price);

    }
}
