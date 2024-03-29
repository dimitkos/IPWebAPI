﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpApi.Interfaces
{
    public interface IMemoryCacheImplementation
    {
        object GetValue(string key);

        void Add(string key, object value, DateTimeOffset absExpiration);

        void Delete(string key);
    }
}
