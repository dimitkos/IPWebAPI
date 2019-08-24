using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalApi.Exceptions
{
    public class IPServiceNotAvailableException : Exception
    {
        public IPServiceNotAvailableException()
        {

        }

        public IPServiceNotAvailableException(string message)
        : base(String.Format("IP Service Not Available: {0}", message))
        {

        }
    }
}
