using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeFit.Models
{
    public class Set
    {
        [Key] 
        public int Id { get; set; }
        public int ExerciseRepetitions { get; set; }
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }
        // Not using this relation
        public ICollection<Profile> Profiles { get; set; }
    }
}
