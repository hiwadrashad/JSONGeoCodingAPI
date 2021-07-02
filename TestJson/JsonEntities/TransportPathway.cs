using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestJson.JsonEntities
{
    public class TransportPathway : TransportNode
    {
        public List<TransportNode> Path { get; set; } = new List<TransportNode>();
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public double StartLatitude { get; set; }
        public double StartLongitude { get; set; }
        public double EndLatitude { get; set; }
        public double EndLongitude { get; set; }
        public bool ErrorFound { get; set; }
    }
}
