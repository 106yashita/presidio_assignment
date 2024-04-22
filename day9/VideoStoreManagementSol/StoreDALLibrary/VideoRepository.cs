using ModelClassLib;
using System.Reflection.Metadata;

namespace StoreDALLibrary
{
    public class VideoRepository : IRepository<int, Video>
    {
        readonly Dictionary<int, Video> _videos;
        public VideoRepository()
        {
            _videos = new Dictionary<int, Video>();
        }
        int GenerateId()
        {
            if (_videos.Count == 0)
                return 1;
            int id = _videos.Keys.Max();
            return ++id;
        }
        public Video Add(Video item)
        {
            if (_videos.ContainsValue(item))
            {
                return null;
            }
            _videos.Add(GenerateId(), item);
            return item;
        }

        public Video Delete(int key)
        {
            if (_videos.ContainsKey(key))
            {
                var video= _videos[key];
                _videos.Remove(key);
                return video;
            }
            return null;
        }

        public Video Get(int key)
        {
            return _videos.ContainsKey(key) ? _videos[key] : null;
        }

        public List<Video> GetAll()
        {
            if (_videos.Count == 0)
                return null;
            return _videos.Values.ToList();
        }

        public Video Update(Video item)
        {
            if (_videos.ContainsKey(item.VideoId))
            {
                _videos[item.VideoId] = item;
                return item;
            }
            return null;
        }
    }
}
