using ExternalApi.Interfaces;
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
        

        public GetIpDetailsResponse FetchIp(GetIpRequest ipRequest)//den einai void tha epistrefei thn ip na thymithw na to allaksw
        {
            if(CheckIfExistInCache(ipRequest))
            {
                return (GetIpDetailsResponse) cacheService.GetValue(ipRequest.Ip);
            }
            
            if(CheckIfIpExistInDatabase(ipRequest))
            {
                var result =  dbService.GetIpDetails(ipRequest);
                //memCacher.Add(token, userId, DateTimeOffset.UtcNow.AddHours(1));
                return result;
            }
            return new GetIpDetailsResponse();//na to svisw den xreiazetai
        }

        
        private bool CheckIfIpExistInDatabase(GetIpRequest ipRequest)
        {
            if(dbService.GetIpDetails(ipRequest) == null)
            {
                return false;
            }
            return true;
        }

        //main logic check if ip exists in cache or in db

        //method ifipexist in cache
        private bool CheckIfExistInCache(GetIpRequest ipRequest)
        {
            if(cacheService.GetValue(ipRequest.Ip) == null)
            {
                return false;
            }
            return true;
        }
        //method if ip exist in db
    }
}
