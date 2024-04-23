using ModelClassLib;
using StoreDALLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBLLibrary
{
    public class RentalBL : IRentalService
    {
        readonly IRepository<int, Rental> _rentalRepository;
        readonly IRepository<int, Video> _videosRepository;
        public RentalBL()
        {
            _rentalRepository = new RentalRepository();
            _videosRepository = new VideoRepository();
        }
        public int AddRentVideo(Rental rental)
        {
            Rental result = _rentalRepository.Add(rental);
            if (result != null)
            {
                return result.Rental_id;
            }
            throw new DuplicateRentalException();
        }

        public double CalculateTotalRentalFeesForCustomer(int customerId)
        {
            double totalRentalFees = 0;
            List<Rental> rentals = _rentalRepository.GetAll();
            foreach (Rental rental in rentals)
            {
                if (rental.Customer_id == customerId)
                {
                    int Video_id=rental.Video_id;
                    Console.WriteLine(Video_id);
                    //Video video = _videosRepository.Get(Video_id);
                    //Console.WriteLine(video.Title);
                    //Console.WriteLine(video.Genre);
                    //Console.WriteLine(video.RentalPrice);
                    //totalRentalFees += video.RentalPrice;
                    totalRentalFees += rental.Late_fee;
                }
            }
            return totalRentalFees;
        }

        public List<Rental> GetOverdueRentals()
        {
            List<Rental> rentals= _rentalRepository.GetAll();
            List<Rental> overduerental = new List<Rental>();
            foreach (Rental rental in rentals)
            {
                if(rental.Return_date > rental.Due_date)
                {
                    overduerental.Add(rental);
                }
            }
            return overduerental;
        }

        public Rental GetRentalById(int rentalId)
        {
            Rental rental = _rentalRepository.Get(rentalId);
            if (rental != null)
            {
                return rental;
            }
            throw new RentalNotExistException();
        }

        public List<Rental> GetRentalsForCustomer(int customerId)
        {
            List<Rental> rentals = _rentalRepository.GetAll();
            List<Rental> customerrental = new List<Rental>();
            foreach (Rental rental in rentals)
            {
                if (rental.Customer_id == customerId)
                {
                    customerrental.Add(rental);
                }
            }
            return customerrental;
        }

        public List<Rental> GetRentalsForVideo(int videoId)
        {
            List<Rental> rentals = _rentalRepository.GetAll();
            List<Rental> videorental = new List<Rental>();
            foreach (Rental rental in rentals)
            {
                if (rental.Video_id == videoId)
                {
                    videorental.Add(rental);
                }
            }
            return videorental;
        }

        public Rental ReturnRentVideo(int rentalId)
        {
           Rental rental = _rentalRepository.Get(rentalId);
           rental.Return_date = DateTime.Now;
           rental.Late_fee = rental.CalculateLateFee(rental.Return_date);
            Rental rental1 = _rentalRepository.Delete(rentalId);
           //Video video= _videosRepository.Get(rental.Video_id);
           //video.UpdateStatus();
           //Console.WriteLine(video.AvailabilityStatus);
           return rental1;
        }
    }
}
