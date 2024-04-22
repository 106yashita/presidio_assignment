using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClassLib
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; }
        public List<int> Rented_videos{ get; set; }

        public Customer()
        {
            CustomerId = 0;
            CustomerName = string.Empty;
            CustomerEmail = string.Empty;
        }

        public Customer(int customerId, string customerName, string customerEmail)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            CustomerEmail = customerEmail;
        }

        public void AddRentedVideo(int video_id)
        {
            Rented_videos.Add(video_id);
        }

        public void RemoveRentedVideo(int video_id)
        {
            if(Rented_videos.Contains(video_id))
            {
                Rented_videos.Remove(video_id);
            }
        }
    }
}
