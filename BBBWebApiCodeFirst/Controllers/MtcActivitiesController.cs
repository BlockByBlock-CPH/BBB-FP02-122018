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
    public class MtcActivitiesController : ControllerBase
    {
        private readonly DataContext _context;

        public MtcActivitiesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/MtcActivities
        [HttpGet]
        public IEnumerable<MtcActivity> GetMtcActivitys()
        {
            return _context.MtcActivitys;
        }

        // GET: api/MtcActivities/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMtcActivity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mtcActivity = await _context.MtcActivitys.FindAsync(id);

            if (mtcActivity == null)
            {
                return NotFound();
            }

            return Ok(mtcActivity);
        }

        // PUT: api/MtcActivities/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMtcActivity([FromRoute] int id, [FromBody] MtcActivity mtcActivity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mtcActivity.IdAct)
            {
                return BadRequest();
            }

            _context.Entry(mtcActivity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MtcActivityExists(id))
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

        // POST: api/MtcActivities
        [HttpPost]
        public async Task<IActionResult> PostMtcActivity([FromBody] MtcActivity mtcActivity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MtcActivitys.Add(mtcActivity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMtcActivity", new { id = mtcActivity.IdAct }, mtcActivity);
        }

        // DELETE: api/MtcActivities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMtcActivity([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mtcActivity = await _context.MtcActivitys.FindAsync(id);
            if (mtcActivity == null)
            {
                return NotFound();
            }

            _context.MtcActivitys.Remove(mtcActivity);
            await _context.SaveChangesAsync();

            return Ok(mtcActivity);
        }

        private bool MtcActivityExists(int id)
        {
            return _context.MtcActivitys.Any(e => e.IdAct == id);
        }
    }
}