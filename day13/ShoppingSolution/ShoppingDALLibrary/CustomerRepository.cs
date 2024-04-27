using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CustomerRepository : AbstractRepository<int, Customer>
    {
        public override async Task<Customer> Delete(int key)
        {
            Customer customer = GetByKey(key).Result;
            if (customer != null)
            {
                items.Remove(customer);
            }
            return customer;
        }

        public override async Task<Customer> GetByKey(int key)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == key)
                    return items[i];
            }
            throw new NoCustomerWithGiveIdException();
        }

        public override async Task<Customer> Update(Customer item)
        {
            Customer customer = GetByKey(item.Id).Result;
            if (customer != null)
            {
                customer = item;
            }
            return customer;
        }
    }
}
