using IpApi.Interfaces;
using IpApi.Types.Request;
using IpApi.Types.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace IpApi.Controllers
{
    public class IpDetailsController : ApiController
    {
        private readonly IMainIpService mainService;

        public IpDetailsController(IMainIpService mainService)
        {
            this.mainService = mainService;
        }

        [HttpGet]
        [ActionName("getIp")]
        public HttpResponseMessage GetIp([FromBody] GetIpRequest ipRequest)
        {
            if(ipRequest ==null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Please give an Ip");
            }

            var response = mainService.FetchIp(ipRequest);

            if (response.IpDetails != null)
            {
                return Request.CreateResponse<GetIpDetailsResponse>(HttpStatusCode.OK, response);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, " Ip Not Found");
            }
        }
    }
}
