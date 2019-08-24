using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IpApi.Types.Request
{
    [DataContract]
    public class GetIpRequest
    {
        [DataMember(Name = "ip")]
        public string Ip { get; set; }
    }
}
