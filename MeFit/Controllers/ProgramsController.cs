using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeFit.Models;
using System.Net.Mime;
using Microsoft.AspNetCore.JsonPatch;

namespace MeFit.Controllers
{
    [Route("api/v1/programs")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ProgramsController : ControllerBase
    {
        private readonly MeFitDBContext _context;

        public ProgramsController(MeFitDBContext context)
        {
            _context = context;
        }

        // GET: api/Programs
        /// <summary>
        /// Get all Programs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Programs>>> GetPrograms()
        {
            return await _context.Programs.ToListAsync();
        }

        // GET: api/Programs/5
        /// <summary>
        /// Get Programs by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Programs>> GetPrograms(int id)
        {
            var programs = await _context.Programs.FindAsync(id);

            if (programs == null)
            {
                return NotFound();
            }

            return programs;
        }

        // PUT: api/Programs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Edit Programs by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="programs"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrograms(int id, Programs programs)
        {
            if (id != programs.Id)
            {
                return BadRequest();
            }

            _context.Entry(programs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramsExists(id))
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

        // POST: api/Programs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add Programs
        /// </summary>
        /// <param name="programs"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Programs>> PostPrograms(Programs programs)
        {
            _context.Programs.Add(programs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrograms", new { id = programs.Id }, programs);
        }

        // DELETE: api/Programs/5
        /// <summary>
        /// Delete Programs by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrograms(int id)
        {
            var programs = await _context.Programs.FindAsync(id);
            if (programs == null)
            {
                return NotFound();
            }

            _context.Programs.Remove(programs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Patch the Programs
        /// </summary>
        /// <param name="id"></param>
        /// <param name="programUpdates"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<ActionResult<Programs>> PatchPrograms(int id, JsonPatchDocument<Programs> programUpdates)
        {
            var programs = await _context.Programs.FindAsync(id);
            if (id != programs.Id)
            {
                return BadRequest();
            }
            programUpdates.ApplyTo(programs);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramsExists(id))
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

        private bool ProgramsExists(int id)
        {
            return _context.Programs.Any(e => e.Id == id);
        }
    }
}
