using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BBBWebApiCodeFirst.Models;
using NetTopologySuite.Geometries;
using Npgsql;
using System.IO;
using BBBWebApiCodeFirst.DataTransferObjects;
using BBBWebApiCodeFirst.DataReaders;
using System.Data;
using BBBWebApiCodeFirst.Converters;
using Newtonsoft.Json.Linq;

namespace BBBWebApiCodeFirst.Controllers
{
    [Route("api/Mtcs")]
    [ApiController]
    public class MtcsController : ControllerBase
    {
        private readonly DataContext _context;

        private static string connectionString = "User ID = mario; Password = abcd; Server = localhost; Port = 5432; Database = BlockDb; Integrated Security = true; Pooling = true;";

        public MtcsController(DataContext context)
        {
            _context = context;

        }

        // GET: api/Mtcs
        [HttpGet]
        public IEnumerable<Mtc> GetMtcs()
        {
            return _context.Mtcs;
        }

        // GET: api/Mtcs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMtc([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mtc = await _context.Mtcs.FindAsync(id);

            if (mtc == null)
            {
                return NotFound();
            }

            return Ok(mtc);
        }


        // GET: api/Mtcs/GetArea/id
        [HttpGet("getarea/{id}")]
        public async Task<IActionResult> GetArea([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mtc = await _context.Mtcs.FindAsync(id);

            var mtcArea = mtc.Area;

            if (mtcArea == null)
            {
                return NotFound();
            }

            return Ok(mtcArea);
        }


        // GET: api/Mtcs/GetGeom/id
        [HttpGet("getgeom/{id}")]
        public async Task<IActionResult> GetGeom([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mtc = await _context.Mtcs.FindAsync(id);

            // var mtcGeom = mtc.Geom.AsText();
            var mtcGeom = mtc.Geom.ToText();

            if (mtcGeom == null)
            {
                return NotFound();
            }
            return Ok(mtcGeom);
        }


        //GET:api/Mtcs/getallrows
        [HttpGet("getallrows")]
        public IEnumerable<Mtc> GetAllRows()
        {
            string _selectString = "SELECT * from \"Mtcs\" limit 3";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<Mtc> MtcList = new List<Mtc>();

                        while (reader.Read())
                        {
                            DataReader dataReader = new DataReader();
                            Mtc mtc = dataReader.ReadMtc(reader);
                            MtcList.Add(mtc);
                        }
                        return MtcList;
                    }
                }
            }         
        }


        //GET:api/Mtcs/gettopchart1week
        [HttpGet("gettopchart1week")]

        public IEnumerable<TopDTO> GetTopChart1Week()
        {
            string _selectString = "SELECT b.\"Id\", a.\"ZoneAct\", SUM(a.\"CountAct\") AS People, b.\"Geom\" FROM \"MtcActivitys\" a INNER JOIN \"Mtcs\" b ON a.\"ZoneAct\" = b.\"Id\" GROUP BY b.\"Id\", a.\"ZoneAct\", b.\"Geom\" ORDER BY People DESC LIMIT 5";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<TopDTO> TopDtoList = new List<TopDTO>();

                        while (reader.Read())
                        {
                            DataReader dataReader = new DataReader();
                            TopDTO topDTO = dataReader.ReadTopDTO(reader);
                            TopDtoList.Add(topDTO);
                        }
                        return TopDtoList;
                    }
                }
            }            
        }


        //GET:api/Mtcs/gettopchart2week/
        [HttpGet("gettopchart2week")]
        public IEnumerable<TopDTO> GetTopChart2week()
        {
            string _selectString = "SELECT b.\"Id\", a.\"ZoneAct\", SUM(a.\"CountAct\") AS People, b.\"Geom\" FROM \"MtcActivitys\" a INNER JOIN \"Mtcs\" b ON a.\"ZoneAct\" = b.\"Id\" GROUP BY b.\"Id\", a.\"ZoneAct\", b.\"Geom\" ORDER BY People ASC LIMIT 5";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<TopDTO> TopDtoList = new List<TopDTO>();

                        while (reader.Read())
                        {
                            DataReader dataReader = new DataReader();
                            TopDTO topDTO = dataReader.ReadTopDTO(reader);
                            TopDtoList.Add(topDTO);
                        }
                        return TopDtoList;
                    }
                }
            }
        }


        //GET:api/Mtcs/gettopchart1day/day
        [HttpGet("gettopchart1day/{day}")]
        public IEnumerable<TopDayDTO> GetTopChart1Day([FromRoute] int day)
        {
            string _selectString = "SELECT b.\"Id\", a.\"DaysAct\", c.\"NameDay\", a.\"ZoneAct\", SUM(a.\"CountAct\") AS People, b.\"Geom\" FROM \"MtcActivitys\" a INNER JOIN \"Mtcs\" b ON a.\"ZoneAct\" = b.\"Id\" INNER JOIN \"Dayss\" c ON a.\"DaysAct\" = c.\"IdDay\" Where a.\"DaysAct\" = " + day + " GROUP BY b.\"Id\", a.\"DaysAct\", c.\"NameDay\", a.\"ZoneAct\", b.\"Geom\" ORDER BY People DESC LIMIT 5";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<TopDayDTO> TopDayDtoList = new List<TopDayDTO>();

                        while (reader.Read())
                        {
                            DataReader dataReader = new DataReader();
                            TopDayDTO topDayDTO = dataReader.ReadTopDayDTO(reader);
                            TopDayDtoList.Add(topDayDTO);
                        }
                       
                        return TopDayDtoList;
                    }
                }
            }
        }


        //GET:api/Mtcs/gettopchart2day/day
        [HttpGet("gettopchart2day/{day}")]
        public IEnumerable<TopDayDTO> GetTopChart2Day([FromRoute] int day)
        {
            string _selectString = "SELECT b.\"Id\", a.\"DaysAct\", c.\"NameDay\", a.\"ZoneAct\", SUM(a.\"CountAct\") AS People, b.\"Geom\" FROM \"MtcActivitys\" a INNER JOIN \"Mtcs\" b ON a.\"ZoneAct\" = b.\"Id\" INNER JOIN \"Dayss\" c ON a.\"DaysAct\" = c.\"IdDay\" Where a.\"DaysAct\" = " + day + " GROUP BY b.\"Id\", a.\"DaysAct\", c.\"NameDay\", a.\"ZoneAct\", b.\"Geom\" ORDER BY People DESC LIMIT 5";

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand(_selectString, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        List<TopDayDTO> TopDayDtoList = new List<TopDayDTO>();

                        while (reader.Read())
                        {
                            DataReader dataReader = new DataReader();
                            TopDayDTO topDayDTO = dataReader.ReadTopDayDTO(reader);
                            TopDayDtoList.Add(topDayDTO);
                        }
                        return TopDayDtoList;
                    }
                }
            }
        }

        //GET:api/Mtcs/getmainchartday/day/longy/lat
        [HttpGet("getmainchartday/{day}/{longy}/{lat}")]
        public JObject GetMainChartDay([FromRoute] int day, double longy, double lat)
        {
            string _pointString = "POINT(" + longy + " " + lat +")";

            string _selectString = "SELECT c.\"Id\", c.\"Gid\", c.\"Area\", a.\"ZoneAct\", b.\"IdDay\", b.\"NameDay\", a.\"HoursAct\", SUM(a.\"CountAct\") AS People, c.\"Geom\" FROM \"MtcActivitys\" a INNER JOIN \"Dayss\" b ON a.\"DaysAct\" = b.\"IdDay\" INNER JOIN \"Mtcs\" c ON a.\"ZoneAct\" = c.\"Gid\" Where ST_Contains(c.\"Geom\", ST_GeomFromText('"+_pointString+"', 4326))=true AND a.\"DaysAct\" = " +day+ " GROUP BY c.\"Id\", c.\"Gid\", a.\"ZoneAct\", b.\"IdDay\", b.\"NameDay\", a.\"HoursAct\", c.\"Geom\" ORDER BY a.\"HoursAct\" ASC";

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
                            DataReader dataReader = new DataReader();
                            MainChartDTO mainChartDTO = dataReader.ReadMainChartDTO(reader);
                            mainChartDtoList.Add(mainChartDTO);
                        }

                        ObjectConverter objConverted = new ObjectConverter();
                        JObject jObject =  objConverted.dayJson(mainChartDtoList);
                        return jObject;
                    }
                }
            }
        }

        //GET:api/Mtcs/getmainchartweek/longy/lat
        [HttpGet("getmainchartweek/{longy}/{lat}")]
        public IEnumerable<MainChartDTO> GetMainChartWeek([FromRoute] double longy, double lat)
        {
            string _pointString = "POINT(" + longy + " " + lat + ")";

            string _selectString = "SELECT c.\"Id\", c.\"Gid\", c.\"Area\", a.\"ZoneAct\", b.\"IdDay\", b.\"NameDay\", a.\"HoursAct\", SUM(a.\"CountAct\") AS People, c.\"Geom\" FROM \"MtcActivitys\" a INNER JOIN \"Dayss\" b ON a.\"DaysAct\" = b.\"IdDay\" INNER JOIN \"Mtcs\" c ON a.\"ZoneAct\" = c.\"Gid\" Where ST_Contains(c.\"Geom\", ST_GeomFromText('" + _pointString + "', 4326))=true GROUP BY c.\"Id\", c.\"Gid\", a.\"ZoneAct\", b.\"IdDay\", b.\"NameDay\", a.\"HoursAct\", c.\"Geom\" ORDER BY a.\"HoursAct\" ASC";

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
                            DataReader dataReader = new DataReader();
                            MainChartDTO mainChartDTO = dataReader.ReadMainChartDTO(reader);
                            mainChartDtoList.Add(mainChartDTO);
                        }
                        return mainChartDtoList;
                    }
                }
            }
        }


        // PUT: api/Mtcs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMtc([FromRoute] int id, [FromBody] Mtc mtc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mtc.Gid)
            {
                return BadRequest();
            }

            _context.Entry(mtc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MtcExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // POST: api/Mtcs
        [HttpPost]
        public async Task<IActionResult> PostMtc([FromBody] Mtc mtc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Mtcs.Add(mtc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMtc", new { id = mtc.Gid }, mtc);
        }

        // DELETE: api/Mtcs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMtc([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mtc = await _context.Mtcs.FindAsync(id);
            if (mtc == null)
            {
                return NotFound();
            }

            _context.Mtcs.Remove(mtc);
            await _context.SaveChangesAsync();

            return Ok(mtc);
        }

        private bool MtcExists(int id)
        {
            return _context.Mtcs.Any(e => e.Gid == id);
        }
    }
}