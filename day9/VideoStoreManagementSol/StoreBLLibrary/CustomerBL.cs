using ModelClassLib;
using StoreDALLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreBLLibrary
{
    public class CustomerBL : ICustomerService
    {
        readonly IRepository<int, Customer> _customerRepository;
        public CustomerBL()
        {
            _customerRepository = new CustomerRepository();
        }
        public int AddCustomer(Customer customer)
        {
            Customer result = _customerRepository.Add(customer);

            if (result != null)
            {
                return result.CustomerId;
            }
            throw new DuplicateCustomerException();
        }

        public void AddRentedVideoToCustomer(int customerId, int videoId)
        {
            Customer customer= _customerRepository.Get(customerId);
            if (customer != null)
            {
                customer.AddRentedVideo(videoId);
            }
            throw new CustomerNotExistException();
        }

        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetCustomerById(int customerId)
        {
           Customer customer = _customerRepository.Get(customerId);
            if (customer != null)
            {
                return customer;
            }
            throw new CustomerNotExistException();
        }

        public Customer RemoveCustomer(int customerId)
        {
            Customer customer = _customerRepository.Delete(customerId);
            if (customer != null)
            { return customer; }
            throw new CustomerNotExistException();
        }

        public void RemoveRentedVideoFromCustomer(int customerId, int videoId)
        {
            Customer customer = _customerRepository.Get(customerId);
            if (customer != null)
            {
                customer.RemoveRentedVideo(videoId);
            }
            throw new CustomerNotExistException();
        }

        public Customer UpdateCustomerDetails(int customerId, Customer updatedCustomer)
        {
            Customer customer= _customerRepository.Get(customerId);
            if (customer != null)
            {
                customer = _customerRepository.Update(updatedCustomer);
            }
            throw new CustomerNotExistException();
        }
    }
}
