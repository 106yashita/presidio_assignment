using ModelClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDALLibrary
{
    public class RentalRepository : IRepository<int, Rental>
    {
        readonly Dictionary<int, Rental> _rentals;
        public RentalRepository()
        {
            _rentals = new Dictionary<int, Rental>();
        }
        int GenerateId()
        {
            if (_rentals.Count == 0)
                return 1;
            int id = _rentals.Keys.Max();
            return ++id;
        }
        public Rental Add(Rental item)
        {
            if (_rentals.ContainsValue(item))
            {
                return null;
            }
            item.Rental_id = GenerateId();
            _rentals.Add(GenerateId(), item);
            return item;
        }

        public Rental Delete(int key)
        {
            if (_rentals.ContainsKey(key))
            {
                var video = _rentals[key];
                _rentals.Remove(key);
                return video;
            }
            return null;
        }

        public Rental Get(int key)
        {
            return _rentals.ContainsKey(key) ? _rentals[key] : null;
        }

        public List<Rental> GetAll()
        {
            if (_rentals.Count == 0)
                return null;
            return _rentals.Values.ToList();
        }

        public Rental Update(Rental item)
        {
            if (_rentals.ContainsKey(item.Rental_id))
            {
                _rentals[item.Rental_id] = item;
                return item;
            }
            return null;
        }
    }
}
