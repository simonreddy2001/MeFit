using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeFit.Models
{
    public class Exercise
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TargetMuscleGroup { get; set; }
        public string Image { get; set; }
        public string VidLink { get; set; }
        public ICollection<Set> Sets { get; set; }
    }
}
