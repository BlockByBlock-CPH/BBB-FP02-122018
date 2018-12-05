using BBBWebApiCodeFirst.Converters;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.DataTransferObjects
{
    public class MainChartDTO
    {
        public int Id { get; set; }

        public int Gid { get; set; }

        public double Area { get; set; }

        public int ZoneAct { get; set; }

        public int IdDay {get; set;}

        public string NameDay { get; set; }

        public int HoursAct { get; set; }

        public int People { get; set; }

        [JsonConverter(typeof(NetTopologySuiteConverter))]
        public Geometry Geom { get; set; }

    }
}
