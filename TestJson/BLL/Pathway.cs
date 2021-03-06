using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestJson.Functions;
using TestJson.JsonEntities;

namespace TestJson.BLL
{
    public class Pathway
    {
        ///
        /// <summary>
        /// Default values for returning default pathway for catching input errors    
        /// </summary>
        /// <param name="pathway"></param>
        /// <param name="StartAdress"></param>
        /// <param name="EndAdress"></param>
        /// <returns></returns>
        /// 
        public static TransportPathway GeneratePathWay (TransportPathway pathway ,string StartAdress = "Utrecht centraal", string EndAdress = "Amersfoort centraal")
        {
 
                var client = new WebClient();
                (string latitude, string Langitude) StartCoordinate = GeoCoding.GetLocation(StartAdress);
                (string latitude, string Langitude) EndCoordinate = GeoCoding.GetLocation(EndAdress);
                var text = client.DownloadString("https://transit.router.hereapi.com/v8/routes?apiKey=etD-X973Kg34aiS8AbEKeptq9SZD3euMf_HM-XKoudQ&origin=" + StartCoordinate.latitude + "," + StartCoordinate.Langitude + "&destination=" + EndCoordinate.latitude + "," + EndCoordinate.Langitude + "&departureTime=2021-07-02T17:00:00");
                GeoDirectionsHEREApiJSONObject post = JsonConvert.DeserializeObject<GeoDirectionsHEREApiJSONObject>(text);
                if (StartCoordinate.Langitude == "0" || StartCoordinate.latitude == "0" || EndCoordinate.Langitude == "0" || EndCoordinate.latitude == "0")
                {
                var defaultinstructions = post.Routes.FirstOrDefault().Sections;
                FillinNodes.FillInNodeData(pathway, defaultinstructions, "Amersfoort centraal");

                (string latitude, string Langitude) StartLocation = GeoCoding.GetLocation("Utrecht centraal");
                    (string latitude, string Langitude) EndLocation = GeoCoding.GetLocation("Amersfoort centraal");
                    pathway.StartLocation = StartAdress;
                    pathway.StartLatitude = StartLocation.latitude;
                    pathway.StartLongitude = StartLocation.Langitude;
                    pathway.EndLocation = EndAdress;
                    pathway.EndLatitude = EndLocation.latitude;
                    pathway.EndLongitude = EndLocation.Langitude;
                    pathway.ErrorFound = true;
                    return pathway;
                }
                var instructions = post.Routes.FirstOrDefault().Sections;
                FillinNodes.FillInNodeData(pathway, instructions, EndAdress);

                pathway.EndLatitude = EndCoordinate.latitude;
                pathway.EndLocation = EndAdress;
                pathway.EndLongitude = EndCoordinate.Langitude;
                pathway.StartLatitude = StartCoordinate.latitude;
                pathway.StartLocation = StartAdress;
                pathway.StartLongitude = StartCoordinate.Langitude;

                return pathway;


            
        }

    }
}
