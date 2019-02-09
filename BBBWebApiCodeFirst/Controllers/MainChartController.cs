using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBBWebApiCodeFirst.Common;
using BBBWebApiCodeFirst.Converters;
using BBBWebApiCodeFirst.DataReaders;
using BBBWebApiCodeFirst.DataTransferObjects;
using BBBWebApiCodeFirst.Interfaces;
using BBBWebApiCodeFirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Npgsql;

namespace BBBWebApiCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainChartController : ControllerBase
    {
        private readonly DataContext _context;
        string connectionString = ConnectionStringBuilder.buildConnectionString();

        public MainChartController(DataContext context)
        {
            _context = context;
        }

        //GET:api/MainChart/getmainchartday/day/longy/lat
        [HttpGet("getmainchartday/{day}/{longy}/{lat}")]
        public JObject GetMainChartDay([FromRoute] int day, double longy, double lat)
        {

            string _selectString = "SELECT day.id, day.description, act.hour, act.people, act.density FROM \"MtcActivitys\" AS act INNER JOIN day AS day ON act.day = day.id INNER JOIN \"Mtcs\" AS zone ON act.zone = zone.id WHERE ST_Contains(zone.geom, ST_SetSRID(ST_MakePoint(" + longy + "," + lat + "), 4326)) AND act.day = "+day+" ORDER BY act.hour ASC";
                       
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<MainChartDTO> mainChartDtoList = new List<MainChartDTO>();

                        while (reader.Read())
                        {
                            InterfaceDataReader dataReader = new DataReader();
                            MainChartDTO mainChartDTO = dataReader.ReadMainChartDTO(reader);
                            mainChartDtoList.Add(mainChartDTO);
                        }
                        
                        IObjectConverter objConverted = new ObjectConverter();
                        var obj = objConverted.MainChartDayJson(mainChartDtoList);

                        return obj;                        
                    }
                }
            }
        }


        //GET:api/MainChart/getmainchartweek/longy/lat
        [HttpGet("getmainchartweek/{longy}/{lat}")]
       
            public JObject GetMainChartWeek([FromRoute] double longy, double lat)
            {        
                string _selectString = "SELECT day.id, day.description, act.hour, act.people, act.density FROM \"MtcActivity\" AS act INNER JOIN day AS day ON act.day = day.id INNER JOIN \"Mtcs\" AS zone ON act.zone = zone.id WHERE ST_Contains(zone.geom, ST_SetSRID(ST_MakePoint(" + longy + "," + lat + "), 4326)) ORDER BY act.day, act.hour ASC";
            
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand(_selectString, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            List<MainChartDTO> mainChartDtoList = new List<MainChartDTO>();

                            while (reader.Read())
                            {
                                InterfaceDataReader dataReader = new DataReader();
                                MainChartDTO mainChartDTO = dataReader.ReadMainChartDTO(reader);
                                mainChartDtoList.Add(mainChartDTO);
                            }

                            IObjectConverter objConverted = new ObjectConverter();                        
                            var obj = objConverted.MainChartWeekJson(mainChartDtoList);
                        
                            return obj;                        
                        }
                    }
                }
        }       
    }
}
