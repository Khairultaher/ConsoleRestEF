﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusyAPI
{
    public static class AppConstants
    {
        public static bool IsProduction = false;

        public const string DbSchema = "busy";

        public static readonly string ConnectionString  = IsProduction
            ? @""
            : @"Data Source=DESKTOP-ODLCJIK;Initial Catalog=TestDB;Integrated Security=True;MultipleActiveResultSets=True;";


        public static readonly string ApiBaseUrl = IsProduction 
            ? "" 
            : "https://api.demo.busy.no";

        public const string X_API_KEY = "X-API-KEY";
        public static readonly string X_API_VALUE = IsProduction 
            ? "" 
            : "cd0c40ce5765bf2103d7537fb75eeef34fd40e6a6e0320dff7a6763c3e43a226";
    }

}
