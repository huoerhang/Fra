using System;
using System.Runtime.Serialization;

namespace Fra
{
    public class FraException : Exception
    {
        public FraException()
        {

        }

        public FraException(string message) : base(message)
        {

        }

        public FraException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public FraException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }
    }
}
