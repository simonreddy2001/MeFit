using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeFit.Models
{
    public class ProgramWorkout
    {
        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }
        public int ProgramId { get; set; }
        public Program Program { get; set; }
    }
}
