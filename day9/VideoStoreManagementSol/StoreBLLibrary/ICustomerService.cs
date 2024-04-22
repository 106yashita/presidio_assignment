using ModelClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBLLibrary
{
    public interface ICustomerService
    {
        int AddCustomer(Customer customer);
        Customer RemoveCustomer(int customerId);
        Customer UpdateCustomerDetails(int customerId, Customer updatedCustomer);
        Customer GetCustomerById(int customerId);
        List<Customer> GetAllCustomers();
        void AddRentedVideoToCustomer(int customerId, int videoId);
        void RemoveRentedVideoFromCustomer(int customerId, int videoId);
    }
}
