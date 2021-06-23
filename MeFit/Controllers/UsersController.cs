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
    [Route("api/v1/users")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class UsersController : ControllerBase
    {
        private readonly MeFitDBContext _context;

        public UsersController(MeFitDBContext context)
        {
            _context = context;
        }

        // GET: api/Users
        /// <summary>
        /// Get all Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        /// <summary>
        /// Get User by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Edit User by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add User 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            var userWithSameEmail = _context.Users.Where(m => m.Email == user.Email).SingleOrDefault(); //checking if the emailid already exits for any user
            if (userWithSameEmail == null)
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetUser", new { id = user.Id }, user);
            }
            return BadRequest();
        }

        // DELETE: api/Users/5
        /// <summary>
        /// Delete User bby Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Patch the User
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userUpdates"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<ActionResult<User>> PatchUser(int id, JsonPatchDocument<User> userUpdates)
        {
            var user = await _context.Users.FindAsync(id);
            if (id != user.Id)
            {
                return BadRequest();
            }
            userUpdates.ApplyTo(user);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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
        /// Get user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("users/{email}")]
        public async Task<ActionResult<User>> GetUserByEmail(string email)
        
        {
            //start doing model validation. no point doing anything if the email passed in is empty ....
            if (string.IsNullOrEmpty(email))
            {
                //return something appropriate for your project
            }
            //New action condition
            //To get employee records
            var table =  from a in _context.Users
                        where a.Email == email
                        select a;
            if (table == null)
            {
                return NotFound();
            }
            return Ok( table);
        }
        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
