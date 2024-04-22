using ModelClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDALLibrary
{
    public class CustomerRepository : IRepository<int, Customer>
    {
        readonly Dictionary<int, Customer> _customers;
        public CustomerRepository()
        {
            _customers = new Dictionary<int, Customer>();
        }
        int GenerateId()
        {
            if (_customers.Count == 0)
                return 1;
            int id = _customers.Keys.Max();
            return ++id;
        }
        public Customer Add(Customer item)
        {
            if (_customers.ContainsValue(item))
            {
                return null;
            }
            item.CustomerId = GenerateId();
            _customers.Add(GenerateId(), item);
            return item;
        }

        public Customer Delete(int key)
        {
            if (_customers.ContainsKey(key))
            {
                var video = _customers[key];
                _customers.Remove(key);
                return video;
            }
            return null;
        }

        public Customer Get(int key)
        {
            return _customers.ContainsKey(key) ? _customers[key] : null;
        }

        public List<Customer> GetAll()
        {
            if (_customers.Count == 0)
                return null;
            return _customers.Values.ToList();
        }

        public Customer Update(Customer item)
        {
            if (_customers.ContainsKey(item.CustomerId))
            {
                _customers[item.CustomerId] = item;
                return item;
            }
            return null;
        }
    }
}
