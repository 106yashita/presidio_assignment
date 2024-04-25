using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary
{
    public class Cart : IEquatable<Cart>
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }//Navigation property

        public List<CartItem> CartItems { get; set; }//Navigation property

        public bool Equals(Cart? other)
        {
            return this.Id.Equals(other.Id);
        }

        public Cart(int id, int customerId, Customer customer, List<CartItem> cartItems)
        {
            Id = id;
            CustomerId = customerId;
            Customer = customer;
            CartItems = cartItems;
        }

        
    }
}
