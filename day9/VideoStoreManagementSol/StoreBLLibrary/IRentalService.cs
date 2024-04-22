using ModelClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBLLibrary
{
    internal interface IRentalService
    {
        int AddRentVideo(Rental rental);
        Rental ReturnRentVideo(int rentalId);
        Rental GetRentalById(int rentalId);
        List<Rental> GetRentalsForCustomer(int customerId);
        List<Rental> GetRentalsForVideo(int videoId);
        List<Rental> GetOverdueRentals();
        double CalculateTotalRentalFeesForCustomer(int customerId);

    }
}
