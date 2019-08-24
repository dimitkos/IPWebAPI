﻿using ExternalApi.Interfaces;
using IpApi.Interfaces;
using IpApi.Types.Request;
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
        
        public MainIpService(IDataBaseService dbService, IIPInfoProvider infoProvider)
        {
            this.dbService = dbService;
            this.infoProvider = infoProvider;
        }
        //main logic check if ip exists in cache or in db

        public void FetchIp(GetIpRequest ipRequest)//den einai void tha epistrefei thn ip na thymithw na to allaksw
        {

        }

        //method ifipexist in cache

        //method if ip exist in db
    }
}