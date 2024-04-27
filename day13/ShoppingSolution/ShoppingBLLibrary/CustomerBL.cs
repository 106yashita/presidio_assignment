using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class CustomerBL : ICustomerService
    {
        private readonly IRepository<int, Customer> _customerRepository;

        [ExcludeFromCodeCoverage]
        public CustomerBL()
        {
            _customerRepository = new CustomerRepository();
        }

        public CustomerBL(IRepository<int, Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer AddCustomer(Customer customer)
        {
            try
            {
                var addedCustomer = _customerRepository.Add(customer);
                return addedCustomer.Result;
            }
            catch (ItemPresentException ex)
            {
                Console.WriteLine(ex.Message);
                throw new ItemPresentException();
            }
            
        }

        public bool DeleteCustomer(int customerId)
        {
            var deletedCustomer = _customerRepository.Delete(customerId);
            if (deletedCustomer != null)
            {
                return true;
            }
            throw new NoCustomerWithGiveIdException();
        }

        [ExcludeFromCodeCoverage]
        public List<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAll().Result.ToList();
           
        }

        public Customer GetCustomerById(int customerId)
        {
            var customer = _customerRepository.GetByKey(customerId);
            if (customer != null)
            {
                return customer.Result;
            }
            throw new NoCustomerWithGiveIdException();
        }

        public Customer UpdateCustomer(Customer customer)
        {
            var updatedCustomer = _customerRepository.Update(customer);
            if (updatedCustomer != null)
            {
                return updatedCustomer.Result;
            }
            throw new NoCustomerWithGiveIdException();
        }
    }
}
