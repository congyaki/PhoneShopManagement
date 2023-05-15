using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneShop.Utilities.Exceptions
{
    public class PhoneShopException : Exception
    {
        public PhoneShopException()
        {

        }

        public PhoneShopException(string message) : base(message)
        {

        }

    }
}
