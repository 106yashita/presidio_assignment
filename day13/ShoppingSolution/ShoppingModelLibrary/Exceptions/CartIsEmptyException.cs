using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class CartIsEmptyException : Exception
    {
        string message;
      public CartIsEmptyException() {
            message = "There is no item in the cart";
        }
        public override string Message => message;
    }
}
