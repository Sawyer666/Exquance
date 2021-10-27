using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameApi.Exceptions
{
    public class IncorrectValueException : Exception
    {
        public IncorrectValueException(string message) : base(message)
        {
        }

        public IncorrectValueException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
