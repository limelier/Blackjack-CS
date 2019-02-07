using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack_1
{
    public class EmptyDeckDrawException : Exception
    {
        public EmptyDeckDrawException()
        {
        }

        public EmptyDeckDrawException(string message)
            :base(message)
        {
        }

        public EmptyDeckDrawException(string message, Exception innerException)
            :base(message, innerException)
        {
        }
    }
}
