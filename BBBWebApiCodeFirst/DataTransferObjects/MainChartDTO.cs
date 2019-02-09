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

        public string Description { get; set; }

        public int Hour { get; set; }

        public int People { get; set; }

        public decimal Density { get; set; }
    }
}
