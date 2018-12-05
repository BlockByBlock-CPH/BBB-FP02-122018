using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BBBWebApiCodeFirst.DataTransferObjects;
using NetTopologySuite.Geometries;
using Newtonsoft.Json.Linq;
using Npgsql;
using BBBWebApiCodeFirst.Models;

namespace BBBWebApiCodeFirst.DataReaders
{
    public class DataReader
    {

        public DataReader ()
        {

        }

        public TopDTO ReadTopDTO(NpgsqlDataReader reader)
        {
            var obj = new JObject();

            int id = reader.GetInt32(0);
            int zoneAct = reader.GetInt32(1);
            int people  = reader.GetInt32(2);
            Geometry geom = reader.GetValue(3) as NetTopologySuite.Geometries.Geometry;

            TopDTO topDTO = new TopDTO
            {
                Id = id,
                ZoneAct = zoneAct,
                People = people,
                Geom = geom
            };
            return topDTO;
        }

        public TopDayDTO ReadTopDayDTO(NpgsqlDataReader reader)
        {
            var obj = new JObject();

            int id = reader.GetInt32(0);
            int daysAct = reader.GetInt32(1);
            string nameDay = reader.GetString(2);
            int zoneAct = reader.GetInt32(3);
            int people = reader.GetInt32(4);
            Geometry geom = reader.GetValue(5) as NetTopologySuite.Geometries.Geometry;

            TopDayDTO topDayDTO = new TopDayDTO
            {
                Id = id,
                DaysAct = daysAct,
                NameDay = nameDay,
                ZoneAct = zoneAct,
                People = people,
                Geom = geom
            };
            return topDayDTO;
        }

        public MainChartDTO ReadMainChartDTO (NpgsqlDataReader reader)
        {
            var obj = new JObject();

            int id = reader.GetInt32(0);
            int gid = reader.GetInt32(1);
            double area = reader.GetDouble(2);
            int zoneAct = reader.GetInt32(3);
            int IdDay = reader.GetInt32(4);
            string nameDay = reader.GetString(5);
            int hoursAct = reader.GetInt32(6);
            int people = reader.GetInt32(7);           
            Geometry geom = reader.GetValue(8) as NetTopologySuite.Geometries.Geometry;

            MainChartDTO mainChartDTO = new MainChartDTO
            {
                Id = id,
                Gid = gid,
                Area = area,
                ZoneAct = zoneAct,
                NameDay = nameDay,
                HoursAct = hoursAct,
                People = people,
                Geom = geom
            };
            return mainChartDTO;
        }


        public Mtc ReadMtc(IDataRecord reader)
        {
            int gid = reader.GetInt32(0);
            long id = reader.GetInt64(1);
            long groesse = reader.GetInt64(2);
            Geometry geom = reader.GetValue(3) as NetTopologySuite.Geometries.Geometry;
            long area = reader.GetInt64(4);


            Mtc mtc = new Mtc
            {
                Gid = gid,
                Id = id,
                Groesse = groesse,
                Geom = geom,
                Area = area
            };

            return mtc;
        }
    }
}
