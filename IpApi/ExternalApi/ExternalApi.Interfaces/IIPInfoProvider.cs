﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExternalApi.Interfaces
{
    public interface IIPInfoProvider
    {
        IPDetails GetDetails(string ip);
    }
}
