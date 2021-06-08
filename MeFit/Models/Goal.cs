using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeFit.Models
{
    public class Goal
    {
        public int Id { get; set; }
        public DateTime EndDate { get; set; }
        public bool Achieved { get; set; }
        public int? ProgramId { get; set; }
        public ICollection<GoalWorkout> GoalWorkouts { get; set; }
    }
}
