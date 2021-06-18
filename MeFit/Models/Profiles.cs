using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeFit.Models
{
    public class Profiles
    {
        [Key] 
        public int Id { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public int? GoalId { get; set; }
        public Goal Goal { get; set; }
        public int? AddressId { get; set; }
        public Address Address { get; set; }
        public int? ProgramId { get; set; }
        public Programs Program { get; set; }
        public int? WorkoutId { get; set; }
        public Workout Workout { get; set; }
        public int? SetId { get; set; }
        public Set Set { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public string MedicalConditions { get; set; }
        public string Disabilities { get; set; }
    }
}
