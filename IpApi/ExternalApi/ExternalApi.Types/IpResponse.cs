using ExternalApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalApi.Types
{
    public class IpResponse : IPDetails
    {
        public string City { get ; set; }
        public string Country { get; set; }
        public string Continent { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
