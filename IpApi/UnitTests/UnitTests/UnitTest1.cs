using System;
using ExternalApi.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetIp()
        {
            IpImplementation service = new IpImplementation();

            string requestIp = "xxx.xxx.xxx.xxx";//must add an ip
            var response = service.GetDetails(requestIp);

            
            Xunit.Assert.NotNull(response.City);
            Xunit.Assert.NotNull(response.Country);
            Xunit.Assert.NotNull(response.Continent);
            Xunit.Assert.True(response.Longitude !=0 && response.Latitude !=0);
        }
    }
}
