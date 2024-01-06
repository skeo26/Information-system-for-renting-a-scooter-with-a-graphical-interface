using System.Runtime.Serialization;

namespace Weesh.BusinessLogic
{
    [Serializable]
    public class InvalidAuthorisationException : Exception
    {
        public InvalidAuthorisationException()
        {
        }

        public InvalidAuthorisationException(string? message) : base(message)
        {
        }

        public InvalidAuthorisationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidAuthorisationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}