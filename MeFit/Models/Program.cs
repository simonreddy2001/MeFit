using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeFit.Models
{
    public class Program
    {
        [Key] 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public ICollection<Profile> Profiles { get; set; }
    }
}
