using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class MaxQuantityExceededException : Exception
    {
        string msg;
        public MaxQuantityExceededException()
        {
            msg = "You cannot add more then 5 item to cart";
        }

        public override string Message => msg;
    }
}
