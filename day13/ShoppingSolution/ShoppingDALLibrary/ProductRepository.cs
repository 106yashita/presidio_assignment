using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class ProductRepository : AbstractRepository<int, Product>
    {
        public override async Task<Product> Delete(int key)
        {
            Product product = GetByKey(key).Result;
            if (product != null)
            {
                items.Remove(product);
            }
            return product;
        }

        public override async Task<Product> GetByKey(int key)
        {
            //Predicate<Product> findProduct =(p)=>p.Id==key;
            //Product product = items.ToList().Find(findProduct);

            //Product product = items.ToList().Find((p) => p.Id == key);

            Product product = items.FirstOrDefault(p => p.Id == key);
            return product;

        }

        public override async Task<Product> Update(Product item)
        {
            Product product = GetByKey(item.Id).Result;
            if (product != null)
            {
                product = item;
            }
            return product;
        }
    }
}
