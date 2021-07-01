using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestJson.JsonEntities;


namespace TestJson.Functions
{
    public static class GeoDirections
    {
        public static void GetDirections()
        {
            //var client = new WebClient();
            //var text = client.DownloadString("https://atlas.microsoft.com/route/directions/json?subscription-key=jwBSZ-1hUkguMOixGEZx2j5r-fYsDSuAilPWxYhLBQA&api-version=1.0&query=52.090736,5.121420:52.370216,4.895168&travelMode=bus&instructionsType=text");
            //GeoDirectionsJSONObject post = JsonConvert.DeserializeObject<GeoDirectionsJSONObject>(text);

            //try
            //{
            //    var instructions = post.Routes.FirstOrDefault().Guidance.Instructions;
            //    foreach (var instruction in instructions)
            //    {
            //        Console.WriteLine(instruction.Message);
            //    }
            //}
            //catch (NullReferenceException ex)
            //{
            //    Console.WriteLine("Incorrect value given");
            //}
        }
    }
}
