﻿using Newtonsoft.Json;
using System;
using System.Net;
using TestJson.JsonEntities;
using System.Linq;
using TestJson.Functions;

namespace TestJson
{
    class Program
    {
        static void Main(string[] args)
        {
            GeoDirectionsHEREApi.GetGeoDirectionsHERE();
        }
    }
}