using System;
using System.Collections.Generic;
using System.Text;

namespace _07._Custom_Exception.Exceptions
{
    class InvalidPersonNameException : Exception
    {
        public InvalidPersonNameException(string message) : base(message)
        {

        }
    }
}
