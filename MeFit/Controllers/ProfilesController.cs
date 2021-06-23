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
    [Route("api/v1/profiles")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ProfilesController : ControllerBase
    {
        private readonly MeFitDBContext _context;

        public ProfilesController(MeFitDBContext context)
        {
            _context = context;
        }

        // GET: api/Profiles
        /// <summary>
        /// Get all Profiles
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Profiles>>> GetProfiles()
        {
            return await _context.Profiles.ToListAsync();
        }

        // GET: api/Profiles/5
        /// <summary>
        /// Get Profile by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Profiles>> GetProfile(int id)
        {
            var profile = await _context.Profiles.FindAsync(id);

            if (profile == null)
            {
                return NotFound();
            }

            return profile;
        }

        // PUT: api/Profiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Edit Profile by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="profile"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfile(int id, Models.Profiles profile)
        {
            if (id != profile.Id)
            {
                return BadRequest();
            }

            _context.Entry(profile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(id))
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

        // POST: api/Profiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add Profile 
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Models.Profiles>> PostProfile(Models.Profiles profile)
        {
            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfile", new { id = profile.Id }, profile);
        }

        // DELETE: api/Profiles/5
        /// <summary>
        /// Delete Profile by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            var profile = await _context.Profiles.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }

            _context.Profiles.Remove(profile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Execute a partial update of the corresponding Profile
        /// </summary>
        /// <param name="id"></param>
        /// <param name="profileUpdates"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<ActionResult<Models.Profiles>> PatchProfile(int id, JsonPatchDocument<Models.Profiles> profileUpdates)
        {
            var profile = await _context.Profiles.FindAsync(id);
            if (id != profile.Id)
            {
                return BadRequest();
            }
            profileUpdates.ApplyTo(profile);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(id))
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
        /// <summary>
        /// Get profile by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("profiles/{email}")]
        public async Task<ActionResult<Models.Profiles>> GetProfileByEmail(string email)

        {
            //start doing model validation. no point doing anything if the email passed in is empty ....
            if (string.IsNullOrEmpty(email))
            {
                //return something appropriate for your project
            }
            //New action condition
            //To get employee records
            var table = from a in _context.Profiles
                        where a.Email == email
                        select a;
            if (table == null)
            {
                return NotFound();
            }
            return Ok(table);
        }
        private bool ProfileExists(int id)
        {
            return _context.Profiles.Any(e => e.Id == id);
        }
    }
}
