using ShoppingDALLibrary;
using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public class CartBL
    {
        readonly IRepository<int, Cart> _CartRepository;
        public CartBL() { 
            _CartRepository=new CartRepository();
        }



    }
}
