using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeFit.Models
{
    public class GoalWorkout
    {
        public DateTime EndDate { get; set; }
        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }
        public int GoalId { get; set; }
        public Goal Goal { get; set; }
    }
}
