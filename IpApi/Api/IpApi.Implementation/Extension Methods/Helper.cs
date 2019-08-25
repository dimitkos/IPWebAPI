using ExternalApi.Types;
using IpApi.Types.DataBaseTypes;
using IpApi.Types.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpApi.Implementation.Extension_Methods
{
    public static class Helper
    {
        public static  WriteIpInDbRequest ConvertRequest(this IpResponse ipResponse,string ip)
        {
            return new WriteIpInDbRequest
            {
                Ip = ip,
                City = ipResponse.City,
                Country = ipResponse.Country,
                Continent = ipResponse.Continent,
                Latitude = ipResponse.Latitude,
                Longitude = ipResponse.Longitude
            };
        }
    }
}
