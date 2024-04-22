using System.Data;

namespace ModelClassLib
{
    public class Video
    {
        public int VideoId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public bool AvailabilityStatus { get; set; }
        public int RentalPrice { get; set; }

        public Video()
        {
            Title = string.Empty;
            Genre = string.Empty;
            AvailabilityStatus = true;
            RentalPrice = 0;
        }

        public Video(int videoId, string title, string genre, int rentalPrice)
        {
            VideoId = videoId;
            Title = title;
            Genre = genre;
            RentalPrice = rentalPrice;
        }

        public void UpdateStatus()
        {
            AvailabilityStatus = !AvailabilityStatus;
        }

    }
}
