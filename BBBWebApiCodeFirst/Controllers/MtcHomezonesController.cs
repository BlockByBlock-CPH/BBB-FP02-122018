using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BBBWebApiCodeFirst.Models;

namespace BBBWebApiCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MtcHomezonesController : ControllerBase
    {
        private readonly DataContext _context;

        public MtcHomezonesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/MtcHomezones
        [HttpGet]
        public IEnumerable<MtcHomezone> GetMtcHomezones()
        {
            return _context.MtcHomezones;
        }

        // GET: api/MtcHomezones/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMtcHomezone([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mtcHomezone = await _context.MtcHomezones.FindAsync(id);

            if (mtcHomezone == null)
            {
                return NotFound();
            }

            return Ok(mtcHomezone);
        }

        // PUT: api/MtcHomezones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMtcHomezone([FromRoute] int id, [FromBody] MtcHomezone mtcHomezone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mtcHomezone.IdHz)
            {
                return BadRequest();
            }

            _context.Entry(mtcHomezone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MtcHomezoneExists(id))
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

        // POST: api/MtcHomezones
        [HttpPost]
        public async Task<IActionResult> PostMtcHomezone([FromBody] MtcHomezone mtcHomezone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MtcHomezones.Add(mtcHomezone);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMtcHomezone", new { id = mtcHomezone.IdHz }, mtcHomezone);
        }

        // DELETE: api/MtcHomezones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMtcHomezone([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mtcHomezone = await _context.MtcHomezones.FindAsync(id);
            if (mtcHomezone == null)
            {
                return NotFound();
            }

            _context.MtcHomezones.Remove(mtcHomezone);
            await _context.SaveChangesAsync();

            return Ok(mtcHomezone);
        }

        private bool MtcHomezoneExists(int id)
        {
            return _context.MtcHomezones.Any(e => e.IdHz == id);
        }
    }
}