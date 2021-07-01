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
            TransportPathway pathway = new TransportPathway();
            var client = new WebClient();
            var text = client.DownloadString("https://transit.router.hereapi.com/v8/routes?apiKey=etD-X973Kg34aiS8AbEKeptq9SZD3euMf_HM-XKoudQ&origin=52.060670,5.122200&destination=52.156113,5.387827&departureTime=2021-07-02T17:00:00");
            GeoDirectionsHEREApiJSONObject post = JsonConvert.DeserializeObject<GeoDirectionsHEREApiJSONObject>(text);

            try
            {
                var instructions = post.Routes.FirstOrDefault().Sections;
                foreach (var instruction in instructions)
                {
                    TransportNode node = new TransportNode();

                    if (!(instruction.Type == "transit"))
                    {
                        if (instruction.Type == "pedestrian")
                        {
                            Console.WriteLine("Lopend");
                        }
                    }
                    if (instruction.Transport.Category == "Train")
                    {
                        Console.WriteLine("Trein " + instruction.Transport.Name);
                    }
                    if (instruction.Transport.Category == "Bus")
                    {
                        Console.WriteLine(instruction.Transport.Category + " " + instruction.Transport.Name);
                    }
                    Console.WriteLine(instruction.Arrival.Place.Name);
                    Console.WriteLine(instruction.Arrival.Time);


                }

                foreach (var item in pathway.Path)
                {
                    Console.WriteLine(item.PlaceAndTime);
                    Console.WriteLine(item.TransportData);
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Incorrect value given");
            }
        }
    }
}

