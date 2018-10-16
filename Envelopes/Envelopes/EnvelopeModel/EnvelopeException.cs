using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envelopes
{
    public class EnvelopeException : Exception
    {
        public EnvelopeException()
        {
        }

        public EnvelopeException(string message) : base(message)
        {
        }

        public EnvelopeException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
