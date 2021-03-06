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
    public class GeoCoding : GeoDirectionsHEREApi
    {
        public static (string Latitude,string Longitude) GetLocation(string Adress)
        {
            var client = new WebClient();
            var text = client.DownloadString("https://geocode.search.hereapi.com/v1/geocode?q=" + Adress + "&apiKey=etD-X973Kg34aiS8AbEKeptq9SZD3euMf_HM-XKoudQ");
            GeoCodingJSONObject post = JsonConvert.DeserializeObject<GeoCodingJSONObject>(text);
            try
            {
                (string latitude, string Langitude) Coordinate = (post.Items.FirstOrDefault().Position.Lat.ToString().Replace(",", "."), post.Items.FirstOrDefault().Position.Lng.ToString().Replace(",", "."));
                Console.WriteLine($"{Coordinate.Langitude.ToString()} , {Coordinate.latitude}");
                return Coordinate;
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (NullReferenceException nullex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                Console.WriteLine("Incorrect value given");
                (string latitude, string Langitude) Coordinate = ("0", "0");
                return Coordinate;
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (WebException webex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                Console.WriteLine("Incorrect value given");
                (string latitude, string Langitude) Coordinate = ("0", "0");
                return Coordinate;
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                Console.WriteLine("Something went wrong");
                (string latitude, string Langitude) Coordinate = ("0", "0");
                return Coordinate;
            }
        }
    }
}
