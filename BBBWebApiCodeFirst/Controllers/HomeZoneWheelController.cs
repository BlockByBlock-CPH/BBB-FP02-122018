using BBBWebApiCodeFirst.Common;
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
    public class HomeZoneWheelController: ControllerBase
    {
        private readonly DataContext _context;
        string connectionString = ConnectionStringBuilder.buildConnectionString();

        public HomeZoneWheelController(DataContext context)
        {
            _context = context;
        }

        //GET:api/HomeZone/gethomezonewheel/day/longy/lat
        [HttpGet("gethomezonewheel/{day}/{longy}/{lat}")]
        public JObject GetHomeZoneWheel([FromRoute] int day, double longy, double lat)
        {
            string _pointString = "POINT(" + longy + " " + lat + ")";
            string _selectString = "SELECT hz.fraction AS fraction, ST_Distance(ST_Centroid(z1.geom)::geography, ST_Centroid(z2.geom)::geography) AS distance, SUM(act.people) *hz.fraction AS people FROM \"MtcHomezones\" AS hz INNER JOIN \"Mtcs\" AS z1 ON z1.id = hz.zone INNER JOIN \"Mtcs\" AS z2 ON z2.id = hz.homezone INNER JOIN \"Mtcs\" AS act ON act.zone = hz.zone AND act.day = hz.day WHERE ST_Contains(z1.geom, ST_SetSRID(ST_MakePoint("+longy+","+lat+"), 4326)) AND hz.day = "+day+" GROUP BY hz.id, z1.geom, z2.geom ORDER BY distance ASC";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<HomeZoneWheelDTO> mainChartDtoList = new List<HomeZoneWheelDTO>();

                        while (reader.Read())
                        {
                            InterfaceDataReader dataReader = new DataReader();
                            MainChartDTO homeZoneWheelDTO = dataReader.ReadHomeZoneWheelDTO(reader);
                            mainChartDtoList.Add(mainChartDTO);
                        }

                        IObjectConverter objConverted = new ObjectConverter();
                        var obj = objConverted.MainChartDayJson(mainChartDtoList);

                        return obj;
                    }
                }
            }

            return new JObject();
        }
    }
}
