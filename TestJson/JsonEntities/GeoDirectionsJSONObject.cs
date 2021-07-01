using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestJson.JsonEntities
{
    public class Summary
    {
        [JsonProperty("lengthInMeters")]
        public int LengthInMeters { get; set; }

        [JsonProperty("travelTimeInSeconds")]
        public int TravelTimeInSeconds { get; set; }

        [JsonProperty("trafficDelayInSeconds")]
        public int TrafficDelayInSeconds { get; set; }

        [JsonProperty("trafficLengthInMeters")]
        public int TrafficLengthInMeters { get; set; }

        [JsonProperty("departureTime")]
        public DateTime DepartureTime { get; set; }

        [JsonProperty("arrivalTime")]
        public DateTime ArrivalTime { get; set; }
    }

    public class Point
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }

    public class Leg
    {
        [JsonProperty("summary")]
        public Summary Summary { get; set; }

        [JsonProperty("points")]
        public List<Point> Points { get; set; }
    }

    //public class Section
    //{
    //    [JsonProperty("startPointIndex")]
    //    public int StartPointIndex { get; set; }

    //    [JsonProperty("endPointIndex")]
    //    public int EndPointIndex { get; set; }

    //    [JsonProperty("sectionType")]
    //    public string SectionType { get; set; }

    //    [JsonProperty("travelMode")]
    //    public string TravelMode { get; set; }
    //}

    public class Point2
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }

    public class Instruction
    {
        [JsonProperty("routeOffsetInMeters")]
        public int RouteOffsetInMeters { get; set; }

        [JsonProperty("travelTimeInSeconds")]
        public int TravelTimeInSeconds { get; set; }

        [JsonProperty("point")]
        public Point Point { get; set; }

        [JsonProperty("pointIndex")]
        public int PointIndex { get; set; }

        [JsonProperty("instructionType")]
        public string InstructionType { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("possibleCombineWithNext")]
        public bool PossibleCombineWithNext { get; set; }

        [JsonProperty("drivingSide")]
        public string DrivingSide { get; set; }

        [JsonProperty("maneuver")]
        public string Maneuver { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("junctionType")]
        public string JunctionType { get; set; }

        [JsonProperty("turnAngleInDecimalDegrees")]
        public int? TurnAngleInDecimalDegrees { get; set; }

        [JsonProperty("combinedMessage")]
        public string CombinedMessage { get; set; }

        [JsonProperty("roadNumbers")]
        public List<string> RoadNumbers { get; set; }

        [JsonProperty("signpostText")]
        public string SignpostText { get; set; }

        [JsonProperty("exitNumber")]
        public string ExitNumber { get; set; }

        [JsonProperty("roundaboutExitNumber")]
        public int? RoundaboutExitNumber { get; set; }
    }

    public class InstructionGroup
    {
        [JsonProperty("firstInstructionIndex")]
        public int FirstInstructionIndex { get; set; }

        [JsonProperty("lastInstructionIndex")]
        public int LastInstructionIndex { get; set; }

        [JsonProperty("groupMessage")]
        public string GroupMessage { get; set; }

        [JsonProperty("groupLengthInMeters")]
        public int GroupLengthInMeters { get; set; }
    }

    public class Guidance
    {
        [JsonProperty("instructions")]
        public List<Instruction> Instructions { get; set; }

        [JsonProperty("instructionGroups")]
        public List<InstructionGroup> InstructionGroups { get; set; }
    }

    //public class Route
    //{
    //    [JsonProperty("summary")]
    //    public Summary Summary { get; set; }

    //    [JsonProperty("legs")]
    //    public List<Leg> Legs { get; set; }

    //    [JsonProperty("sections")]
    //    public List<Section> Sections { get; set; }

    //    [JsonProperty("guidance")]
    //    public Guidance Guidance { get; set; }
    //}

    public class GeoDirectionsJSONObject
    {
        [JsonProperty("formatVersion")]
        public string FormatVersion { get; set; }

        [JsonProperty("routes")]
        public List<Route> Routes { get; set; }
    }

}
