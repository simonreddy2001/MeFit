using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeFit.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Complete { get; set; }
        public int? SetId { get; set; }
        public ICollection<Profile> Profiles { get; set; }
        public ICollection<Set> Sets { get; set; }
        public ICollection<GoalWorkout> GoalWorkouts { get; set; }
    }
}
