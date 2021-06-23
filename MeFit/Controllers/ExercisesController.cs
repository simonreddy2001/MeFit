using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeFit.Models;
using System.Net.Mime;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;

namespace MeFit.Controllers
{
    [Route("api/v1/exercises")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ExercisesController : ControllerBase
    {
        private readonly MeFitDBContext _context;
        
        public ExercisesController(MeFitDBContext context)
        {
            _context = context;
        }

        // GET: api/Exercises
        /// <summary>
        /// Get all Exercises
        /// </summary>
        /// <returns></returns>
       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exercise>>> GetExercises()
        {
            return await _context.Exercises.ToListAsync();
        }

        // GET: api/Exercises/5
        /// <summary>
        /// Get Exercise by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Exercise>> GetExercise(int id)
        {
            var exercise = await _context.Exercises.FindAsync(id);

            if (exercise == null)
            {
                return NotFound();
            }

            return exercise;
        }

        // PUT: api/Exercises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Edit Exercise byId
        /// </summary>
        /// <param name="id"></param>
        /// <param name="exercise"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExercise(int id, Exercise exercise)
        {
            if (id != exercise.Id)
            {
                return BadRequest();
            }

            _context.Entry(exercise).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseExists(id))
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

        // POST: api/Exercises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Add Exercise 
        /// </summary>
        /// <param name="exercise"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Exercise>> PostExercise(Exercise exercise)
        {
            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExercise", new { id = exercise.Id }, exercise);
        }

        // DELETE: api/Exercises/5
        /// <summary>
        /// Delete Exercise by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercise(int id)
        {
            var exercise = await _context.Exercises.FindAsync(id);
            if (exercise == null)
            {
                return NotFound();
            }

            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Update an item of an specific exercise by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="exerciseUpdates"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public async Task<ActionResult<Exercise>> PatchExercise(int id, JsonPatchDocument<Exercise> exerciseUpdates)
        {
            var exercise = await _context.Exercises.FindAsync(id);
            if (id != exercise.Id)
            {
                return BadRequest();
            }
            exerciseUpdates.ApplyTo(exercise);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseExists(id))
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

        private bool ExerciseExists(int id)
        {
            return _context.Exercises.Any(e => e.Id == id);
        }
    }
}
