using System.Runtime.Serialization;

namespace Weesh.BusinessLogic
{
    [Serializable]
    public class InvalidCreateNewUserException : Exception
    {
        public InvalidCreateNewUserException()
        {
        }

        public InvalidCreateNewUserException(string? message) : base(message)
        {
        }

        public InvalidCreateNewUserException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidCreateNewUserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}