using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeFit.Models
{
    public class Program
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Catagory { get; set; }
        public ICollection<Profile> Profiles { get; set; }
    }
}
