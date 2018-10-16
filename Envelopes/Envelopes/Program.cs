using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envelopes
{
    public class Program
    {
        public static int Main(string[] args)
        {
            NestingEnvelopeApplication myApplication = new NestingEnvelopeApplication();
            return myApplication.Run(args);
        }
    }
}
