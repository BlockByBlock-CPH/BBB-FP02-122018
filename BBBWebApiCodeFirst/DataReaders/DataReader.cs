 using BBBWebApiCodeFirst.DataTransferObjects;
using BBBWebApiCodeFirst.Interfaces;
using BBBWebApiCodeFirst.Models;
using NetTopologySuite.Geometries;
using Newtonsoft.Json.Linq;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BBBWebApiCodeFirst.DataReaders
{
    public class DataReader: InterfaceDataReader
    {

        public DataReader()
        {

        }

        public TopDayDTO ReadTopDayDTO(NpgsqlDataReader reader)
        {
            var obj = new JObject();

            int gid = reader.GetInt32(0);
            int id = reader.GetInt32(1);
            int daysAct = reader.GetInt32(2);            
            int zoneAct = reader.GetInt32(3);
            int people = reader.GetInt32(4);
            Geometry geom = reader.GetValue(5) as NetTopologySuite.Geometries.Geometry;

            TopDayDTO topDayDTO = new TopDayDTO
            {
                Gid = gid,
                Id = id,
                DaysAct = daysAct,                
                ZoneAct = zoneAct,
                People = people,
                Geom = geom
            };
            return topDayDTO;
        }

        public MainChartDTO ReadMainChartDTO(NpgsqlDataReader reader)
        {
            var obj = new JObject();

            int id = reader.GetInt32(0);
            string day = reader.GetString(1);
            int hour = reader.GetInt32(2);
            int people = reader.GetInt32(3);
            decimal density = reader.GetDecimal(4);
                        
            MainChartDTO mainChartDTO = new MainChartDTO
            {
                Id = id,
                Day = day,
                Hour = hour,
                People = people,
                Density = density
            };

            return mainChartDTO;
        }

        public TopDTO ReadTopDTO(NpgsqlDataReader reader)
        {
            int gid = reader.GetInt32(0);
            int id = reader.GetInt32(1);
            int zoneAct = reader.GetInt32(2);
            int people = reader.GetInt32(3);
            Geometry geom = reader.GetValue(4) as NetTopologySuite.Geometries.Geometry;

            TopDTO topDTO = new TopDTO
            {
                Id = id,
                ZoneAct = zoneAct,
                People = people,
                Geom = geom
            };
            return topDTO;
        }

        public TableHomeDayDTO ReadTableHomeDayDTO (NpgsqlDataReader reader)
        {
            int id = reader.GetInt32(0);
            string description = reader.GetString(1);
            int hour = reader.GetInt32(2);
            int people = reader.GetInt32(3);

            TableHomeDayDTO tableHomeDayDTO = new TableHomeDayDTO
            {
                Id = id,
                Description = description,
                Hour = hour,
                People = people                
            };

            return tableHomeDayDTO;
        }

        public TableHomeWeekDTO ReadTableHomeWeekDTO(NpgsqlDataReader reader)
        {
            int id = reader.GetInt32(0);
            string description = reader.GetString(1);
            int people = reader.GetInt32(2);            
            
            TableHomeWeekDTO tableHomeWeekDTO = new TableHomeWeekDTO
            {                
                Id = id,
                Description = description,
                People = people                
            };

            return tableHomeWeekDTO;
        }

        public AreaOfInfluenceDTO ReadAreaOfInfluenceDTO(NpgsqlDataReader reader)
        {
            decimal area = reader.GetDecimal(0);

            AreaOfInfluenceDTO areaOfInfluenceDTO = new AreaOfInfluenceDTO
            {
                Area = area
            };
            return areaOfInfluenceDTO;            
            
        }

        public HomeZoneWheelDTO ReadHomeZoneWheelDTO(NpgsqlDataReader reader)
        {
            decimal fraction = reader.GetDecimal(0);
            int distance = reader.GetInt32(1);
            int people = reader.GetInt32(2);

            HomeZoneWheelDTO areaOfInfluenceDTO = new HomeZoneWheelDTO
            {
                Fraction = fraction,
                Distance = distance,
                People = people
            };

            return areaOfInfluenceDTO;

        }
    }
}