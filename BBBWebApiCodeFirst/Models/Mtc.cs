using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BBBWebApiCodeFirst.Converters;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;

namespace BBBWebApiCodeFirst.Models
{
    public class Mtc
    {
        [Key]
        public int Gid { get; set; }

        public decimal? Id { get; set; }

        public decimal? Groesse { get; set; }

        [JsonConverter(typeof(NetTopologySuiteConverter))]
        public Geometry Geom { get; set; }

        public decimal? Area { get; set; }
    }
}
