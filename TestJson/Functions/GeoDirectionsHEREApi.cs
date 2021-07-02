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
    public class GeoDirectionsHEREApi
    {
        public static void GetGeoDirectionsHERE(string StartAdress, string EndAdress)
        {
            TransportPathway pathway = new TransportPathway();
            var client = new WebClient();
            (string latitude, string Langitude) StartCoordinate = GeoCoding.GetLocation(StartAdress);
            (string latitude, string Langitude) EndCoordinate = GeoCoding.GetLocation(EndAdress);
            var text = client.DownloadString("https://transit.router.hereapi.com/v8/routes?apiKey=etD-X973Kg34aiS8AbEKeptq9SZD3euMf_HM-XKoudQ&origin=" + StartCoordinate.latitude + "," + StartCoordinate.Langitude + "&destination=" + EndCoordinate.latitude + "," + EndCoordinate.Langitude + "&departureTime=2021-07-02T17:00:00");
            GeoDirectionsHEREApiJSONObject post = JsonConvert.DeserializeObject<GeoDirectionsHEREApiJSONObject>(text);

            try
            {
                var instructions = post.Routes.FirstOrDefault().Sections;
                var LastIndex = instructions.Last();
                foreach (var instruction in instructions)
                {
                    TransportNode node = new TransportNode();

                    if (!(instruction.Type == "transit"))
                    {
                        if (instruction.Type == "pedestrian")
                        {
                            //Console.WriteLine("Lopend");
                            node.TransportData = "Lopend";
                        }
                    }
                    if (instruction.Transport.Category == "Train")
                    {
                        //Console.WriteLine("Trein " + instruction.Transport.Name);
                        node.TransportData = ("Trein " + instruction.Transport.Name);
                    }
                    if (instruction.Transport.Category == "Bus")
                    {
                        //Console.WriteLine(instruction.Transport.Category + " " + instruction.Transport.Name);
                        node.TransportData = (instruction.Transport.Category + " " + instruction.Transport.Name);
                    }
                    //Console.WriteLine(instruction.Arrival.Place.Name);
                    node.PlaceAndTime = instruction.Arrival.Place.Name;
                    //Console.WriteLine(instruction.Arrival.Time);
                    if (instruction.Equals(LastIndex))
                    {
                        node.PlaceAndTime = EndAdress;
                    }
                    node.PlaceAndTime = (node.PlaceAndTime + " | " + instruction.Arrival.Time);

                    pathway.Path.Add(node);


                }

                
                foreach (var item in pathway.Path)
                {
                    Console.WriteLine(item.PlaceAndTime);
                    Console.WriteLine(item.TransportData);
                    Console.WriteLine("");
                }

            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (NullReferenceException nullex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                Console.WriteLine("Incorrect value given");
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (WebException webex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                Console.WriteLine("Incorrect value given");
            }

#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex)
#pragma warning restore CS0168 // Variable is declared but never used
            {
                Console.WriteLine("Something went wrong");
            }
        }
    }
}

