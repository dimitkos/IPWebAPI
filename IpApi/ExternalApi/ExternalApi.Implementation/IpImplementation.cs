using ExternalApi.Interfaces;
using ExternalApi.Types;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalApi.Implementation
{
    public class IpImplementation : IIPInfoProvider
    {
        public IPDetails GetDetails(string ip)
        {
            try
            {
                var client = new RestClient("http://api.ipstack.com");
                var request = new RestRequest("/{ip} ? access_key =f6a6d50dea98aaf41a1c2fd8e90974fb", Method.GET);
                var queryResult = client.Get<IpResponse>(request).Data;
                return queryResult;
            }
            catch(Exception ex)
            {
                throw new Exception("IPServiceNotAvailableException");
            }
            
        }
    }
}
