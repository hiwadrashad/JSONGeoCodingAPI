using Newtonsoft.Json;
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
            //GeoCoding.GetLocation("Tjepmahof");
            //GeoDirectionsHEREApi.GetGeoDirectionsHERE("Utrecht centraal","Amersfoort centraal");
            Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmss"));
        }
    }
}
