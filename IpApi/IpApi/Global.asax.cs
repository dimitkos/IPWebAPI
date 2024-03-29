﻿using ExternalApi.Implementation;
using ExternalApi.Interfaces;
using IpApi.Implementation;
using IpApi.Interfaces;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace IpApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<IDataBaseService, DataBaseImplementation>(Lifestyle.Scoped);
            container.Register<IMainIpService, MainIpService>(Lifestyle.Scoped);
            container.Register<IIPInfoProvider, IpImplementation>(Lifestyle.Scoped);
            container.Register<IMemoryCacheImplementation, MemoryCacheImplementation>(Lifestyle.Scoped);
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);


            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
