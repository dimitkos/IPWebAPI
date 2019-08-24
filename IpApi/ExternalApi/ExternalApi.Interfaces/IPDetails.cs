using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalApi.Interfaces
{
    public interface IPDetails
    {
        string City { get; set; }
        string Country { get; set; }
        string Continent { get; set; }
        string Latitude { get; set; }
        string Longitude { get; set; }

    }
}
