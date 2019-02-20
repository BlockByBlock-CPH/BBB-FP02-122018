using BBBWebApiCodeFirst.Common;
using BBBWebApiCodeFirst.Converters;
using BBBWebApiCodeFirst.DataReaders;
using BBBWebApiCodeFirst.DataTransferObjects;
using BBBWebApiCodeFirst.Interfaces;
using BBBWebApiCodeFirst.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AreaInfluenceController: ControllerBase
    {

        private readonly DataContext _context;
        string connectionString = ConnectionStringBuilder.buildConnectionString();

        //GET:api/AreaInfluence/getareainfluenceday/day/longy/lat
        [HttpGet("getareainfluenceday/{day}/{longy}/{lat}")]
        public JObject GetAreaInfluenceDay([FromRoute] int day, double longy, double lat)
        {
            string _pointString = "POINT(" + longy + " " + lat + ")";
            string _selectString = "SELECT SUM(ST_Area(zone.\"Geom\"::geography))/1000000 AS area FROM \"MtcHomezones\" AS hz INNER JOIN \"Mtcs\" AS zone ON zone.\"Gid\" = hz.\"HomeHz\" WHERE hz.\"ZoneHz = " + _pointString + " AND hz.days_hz = " + day + "";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<AreaOfInfluenceDTO> AreaOfInfluenceDtoList = new List<AreaOfInfluenceDTO>();

                        while (reader.Read())
                        {
                            InterfaceDataReader dataReader = new DataReader();
                            AreaOfInfluenceDTO areaOfInfluenceDTO = dataReader.ReadAreaOfInfluenceDTO(reader);
                            AreaOfInfluenceDtoList.Add(areaOfInfluenceDTO);
                        }

                        IObjectConverter objConverted = new ObjectConverter();
                        var obj = objConverted.AreaOfInfluenceDayJson(AreaOfInfluenceDtoList);

                        return obj;
                    }
                }
            }
            return new JObject();
        }

        //GET:api/AreaInfluence/getareainfluenceweek/day/longy/lat
        [HttpGet("getareainfluenceweek/{longy}/{lat}")]
        public JObject GetAreaInfluenceWeek([FromRoute] double longy, double lat)
        {
            string _pointString = "POINT(" + longy + " " + lat + ")";
            string _selectString = "SELECT SUM(area)/1000000 AS area FROM(SELECT DISTINCT ON(\"HomeHz\") ST_Area(zone.\"Geom\"::geography) AS area FROM \"MtcHomezone\" AS hz INNER JOIN \"Mtc\" AS zone ON zone.\"Gid\" = hz.\"HomeHz\" WHERE hz.\"ZoneHz\" = " + _pointString + ") s";

            //using (var conn = new NpgsqlConnection(connectionString))
            //{
            //    conn.Open();

            //    using (var cmd = new NpgsqlCommand(_selectString, conn))
            //    {
            //        using (var reader = cmd.ExecuteReader())
            //        {
            //            List<MainChartDTO> mainChartDtoList = new List<MainChartDTO>();

            //            while (reader.Read())
            //            {
            //                InterfaceDataReader dataReader = new DataReader();
            //                MainChartDTO mainChartDTO = dataReader.ReadMainChartDTO(reader);
            //                mainChartDtoList.Add(mainChartDTO);
            //            }

            //            IObjectConverter objConverted = new ObjectConverter();
            //            var obj = objConverted.MainChartDayJson(mainChartDtoList);

            //            return obj;
            //        }
            //    }
            //}


            return new JObject();
        }
    }
}
