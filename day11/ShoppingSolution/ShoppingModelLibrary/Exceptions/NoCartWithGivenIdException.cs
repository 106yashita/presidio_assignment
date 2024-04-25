using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class NoCartWithGivenIdException : Exception
    {
        string msg;
        public NoCartWithGivenIdException()
        {
            msg = "No card is present";
        }

        public override string Message => msg;
    }
}
