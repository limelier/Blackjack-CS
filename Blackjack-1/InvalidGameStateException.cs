using System;
using System.Runtime.Serialization;

namespace Blackjack_1
{
    [Serializable]
    internal class InvalidGameStateException : Exception
    {
        public InvalidGameStateException()
        {
        }

        public InvalidGameStateException(string message) : base(message)
        {
        }

        public InvalidGameStateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidGameStateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}