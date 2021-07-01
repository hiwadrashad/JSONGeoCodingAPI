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
    public static class GeoCoding
    {
        public static void GetLocation()
        {
            var client = new WebClient();
            var text = client.DownloadString("https://geocode.search.hereapi.com/v1/geocode?q=Tjepmahof&apiKey=etD-X973Kg34aiS8AbEKeptq9SZD3euMf_HM-XKoudQ");
            GeoCodingJSONObject post = JsonConvert.DeserializeObject<GeoCodingJSONObject>(text);

            try
            {
                Console.WriteLine(post.Items.FirstOrDefault().Position.Lat);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Incorrect value given");
            }
        }
    }
}
