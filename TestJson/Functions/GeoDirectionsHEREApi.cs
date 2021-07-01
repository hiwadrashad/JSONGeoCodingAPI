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
    public static class GeoDirectionsHEREApi
    {
        public static void GetGeoDirectionsHERE()
        {
            var client = new WebClient();
            var text = client.DownloadString("https://transit.router.hereapi.com/v8/routes?apiKey=etD-X973Kg34aiS8AbEKeptq9SZD3euMf_HM-XKoudQ&origin=52.060670,5.122200&destination=52.091259,5.122750&departureTime=2021-07-02T17:00:00");
            GeoDirectionsHEREApiJSONObject post = JsonConvert.DeserializeObject<GeoDirectionsHEREApiJSONObject>(text);

            try
            {
                var instructions = post.Routes.FirstOrDefault().Sections;
                foreach (var instruction in instructions)
                {
                    if (!(instruction.Type == "transit"))
                    {
                        Console.WriteLine(instruction.Type);
                    }
                    Console.WriteLine(instruction.Transport.Category + " " + instruction.Transport.Name);
                    Console.WriteLine(instruction.Arrival.Time);
                    //Console.WriteLine(instruction.Departure.Place.Name);
                    Console.WriteLine(instruction.Arrival.Place.Name);
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Incorrect value given");
            }
        }
    }
}
