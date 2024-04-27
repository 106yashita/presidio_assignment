using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CartItemRepository : AbstractRepository<int, CartItem>
    {
        public override async Task<CartItem> Delete(int key)
        {
            CartItem cartItem = GetByKey(key).Result;
            if (cartItem != null)
            {
                items.Remove(cartItem);
            }
            return cartItem;
        }

        public override async Task<CartItem> GetByKey(int key)
        {
            CartItem cartItem = items.FirstOrDefault(c => c.CartId == key);
            return cartItem;
        }

        public override async Task<CartItem> Update(CartItem item)
        {
            CartItem cartItem = GetByKey(item.CartId).Result;
            if ( cartItem!= null)
            {
                cartItem = item;
            }
            return cartItem;
        }
    }
}
