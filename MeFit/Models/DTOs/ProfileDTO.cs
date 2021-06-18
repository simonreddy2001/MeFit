using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeFit.Models.DTOs
{
    public class ProfileDTO 
    {
        public int Id { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public string MedicalConditions { get; set; }
        public string Disabilities { get; set; }
    }
}
