﻿using IpApi.Types.Request;
using IpApi.Types.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpApi.Interfaces
{
    public interface IMainIpService
    {
        GetIpDetailsResponse FetchIp(GetIpRequest ipRequest);
    }
}
