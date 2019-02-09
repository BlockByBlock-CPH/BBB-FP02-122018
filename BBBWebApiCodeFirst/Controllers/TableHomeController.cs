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
    public class TableHomeController : ControllerBase
    {
        private readonly DataContext _context;
        string connectionString = ConnectionStringBuilder.buildConnectionString();


        public TableHomeController(DataContext context)
        {
            _context = context;
        }

        //GET:api/TableHome/gettablehomeday/day/longy/lat
        [HttpGet("gettablehomeday/{day}/{longy}/{lat}")]
        public JObject GetTableHomeDay([FromRoute] int day, double longy, double lat)
        {
             string _selectString = "SELECT day.id AS day, day.description, act.hour, act.people FROM \"MtcActivitys\" AS act INNER JOIN day ON act.day = day.id WHERE ST_Contains(zone.geom, ST_SetSRID(ST_MakePoint($1, $2), 4326)) AND day = 1 AND (people = (SELECT MAX(act.people) FROM \"MtcActivitys\" As act INNER JOIN mtc AS zone ON act.zone = zone.id WHERE ST_Contains(zone.geom, ST_SetSRID(ST_MakePoint(" + longy + "," + lat + "), 4326)) AND act.day = "+day+ ") OR people = (SELECT MIN(act.people) FROM \"MtcActivitys\" AS act INNER JOIN mtc AS zone ON act.zone = zone.id WHERE ST_Contains(zone.geom, ST_SetSRID(ST_MakePoint(" + longy + "," + lat + "), 4326)) AND act.day = "+day+")) ORDER BY people DESC";
            
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<TableHomeDayDTO> tableHomeDayDtoList = new List<TableHomeDayDTO>();

                        while (reader.Read())
                        {
                            InterfaceDataReader dataReader = new DataReader();
                            TableHomeDayDTO tableHomeDayDTO = dataReader.ReadTableHomeDayDTO(reader);
                            tableHomeDayDtoList.Add(tableHomeDayDTO);
                        }

                        IObjectConverter objConverted = new ObjectConverter();
                        var obj = objConverted.TableHomeDayJson(tableHomeDayDtoList);

                        return obj;
                    }
                }
            }
        }

        // GET:api/TableHome/gettablehomeweek/longy/lat
        [HttpGet("gettablehomeweek/{longy}/{lat}")]
        public JObject GetTableHomeWeek([FromRoute] double longy, double lat)
        {
            string _selectString = "SELECT day.id AS day, day.description, SUM(act.people) AS people FROM \"MtcActivitys\" AS act INNER JOIN day ON act.day = day.id INNER JOIN mtc AS zone ON act.zone = zone.id WHERE ST_Contains(zone.geom, ST_SetSRID(ST_MakePoint("+longy+","+lat+"), 4326)) GROUP BY day.id HAVING SUM(people) >= ALL(SELECT SUM(people) FROM \"MtcActivitys\" AS act INNER JOIN \"Mtc\" AS zone ON act.zone = zone.id WHERE ST_Contains(zone.geom, ST_SetSRID(ST_MakePoint(+"+longy+", "+lat+"), 4326)) GROUP BY day) OR SUM(people) <= ALL(SELECT SUM(people) FROM \"MtcActivity\" AS act INNER JOIN \"Mtc\" AS zone ON act.zone = zone.id WHERE ST_Contains(zone.geom, ST_SetSRID(ST_MakePoint("+longy+","+lat+"), 4326)) GROUP BY day) ORDER BY people DESC";
            
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<TableHomeWeekDTO> tableHomeWeekDtoList = new List<TableHomeWeekDTO>();

                        while (reader.Read())
                        {
                            InterfaceDataReader dataReader = new DataReader();
                            TableHomeWeekDTO tableHomeWeekDTO = dataReader.ReadTableHomeWeekDTO(reader);
                            tableHomeWeekDtoList.Add(tableHomeWeekDTO);
                        }

                        IObjectConverter objConverted = new ObjectConverter();
                        var obj = objConverted.TableHomeWeekJson(tableHomeWeekDtoList);

                        return obj;
                    }
                }
            }
        }
    }
}
