using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClassLib
{
    public class Rental
    {
        public int Rental_id { get; set; }
        public int Customer_id { get; set; }
        public int Video_id { get; set; }
        public DateTime Rental_date { get; set; }
        public DateTime Due_date { get; set; }
        public DateTime Return_date { get; set; }
        public double Late_fee { get; set; }

        public Rental()
        {
            Rental_id = 0;
            Customer_id = 0;
            Video_id = 0;
            Rental_date = new DateTime();
            Due_date = new DateTime();
            Return_date = new DateTime();
            Late_fee = 0;
        }

        public Rental(int rental_id, int customer_id, int video_id, DateTime due_date, DateTime return_date)
        {
            Rental_id = rental_id;
            Customer_id = customer_id;
            Video_id = video_id;
            Due_date = due_date;
            Return_date = return_date;
        }

        public double CalculateLateFee(DateTime return_date)
        {
            if (return_date > Due_date)
            {
                int daysLate = (return_date - Due_date).Days;
                double lateFeePerDay = 1.50;
                double lateFee = daysLate * lateFeePerDay;
                return lateFee;
            }
            else
            {
                return 0;
            }
        }
    }
}
