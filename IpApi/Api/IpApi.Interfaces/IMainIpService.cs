using IpApi.Types.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpApi.Interfaces
{
    public interface IMainIpService
    {
        void FetchIp(GetIpRequest ipRequest);
    }
}
