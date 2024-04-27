using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class ItemPresentException : Exception
    {
        string message;
        public ItemPresentException()
        {
            message = "Item already present";
        }
        public override string Message => message;
    }
}
