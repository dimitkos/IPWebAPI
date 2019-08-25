using ExternalApi.Interfaces;
using ExternalApi.Types;
using IpApi.Interfaces;
using IpApi.Types.Request;
using IpApi.Types.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpApi.Implementation
{
    public class MainIpService : IMainIpService
    {
        private readonly IDataBaseService dbService;
        private readonly IIPInfoProvider infoProvider;
        private readonly IMemoryCacheImplementation cacheService;
        

        public MainIpService(IDataBaseService dbService, IIPInfoProvider infoProvider, IMemoryCacheImplementation cacheService)
        {
            this.dbService = dbService;
            this.infoProvider = infoProvider;
            this.cacheService = cacheService;
        }
        

        public GetIpDetailsResponse FetchIp(GetIpRequest ipRequest)
        {

            if (CheckIfExistInCache(ipRequest))
            {
                return (GetIpDetailsResponse) cacheService.GetValue(ipRequest.Ip);
            }

            if (CheckIfIpExistInDatabase(ipRequest))
            {
                FetchIpFromDbIfExistAndCache(ipRequest);
            }
            else
            {
                //must refactor this to other  methods
                IpResponse resultFromLib = (IpResponse)infoProvider.GetDetails(ipRequest.Ip);

                if (resultFromLib != null)
                {
                    WriteIpInDbRequest writeInDbRequest = new WriteIpInDbRequest//to investigate why extension method dont work
                    {
                        Ip = ipRequest.Ip,
                        City = resultFromLib.City,
                        Country = resultFromLib.Country,
                        Continent = resultFromLib.Continent,
                        Latitude = resultFromLib.Latitude,
                        Longitude = resultFromLib.Longitude
                    };
                    dbService.WriteIpDetailsinDataBase(writeInDbRequest);
                    cacheService.Add(ipRequest.Ip, ipRequest.Ip, DateTimeOffset.UtcNow.AddHours(1));
                    //must return the ip from library
                }
            }

            return new GetIpDetailsResponse();//must fix this
        }

        #region private methods
        private bool CheckIfIpExistInDatabase(GetIpRequest ipRequest)
        {
            if(dbService.GetIpDetails(ipRequest) == null)
            {
                return false;
            }
            return true;
        }

        private GetIpDetailsResponse FetchIpFromDbIfExistAndCache(GetIpRequest ipRequest)
        {
            var result = dbService.GetIpDetails(ipRequest);
            cacheService.Add(ipRequest.Ip, ipRequest.Ip, DateTimeOffset.UtcNow.AddHours(1));
            return result;

        }

        private bool CheckIfExistInCache(GetIpRequest ipRequest)
        {
            if(cacheService.GetValue(ipRequest.Ip) == null)
            {
                return false;
            }
            return true;
        }

        #endregion
    }
}
