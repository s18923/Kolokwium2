using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Kolokwium2.Exceptions
{
    public class TooOldException : Exception
    {
        public TooOldException()
        {
        }

        public TooOldException(string message) : base(message)
        {
        }

        public TooOldException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TooOldException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
