﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MeFit.Models
{
    public class User
    {
        [Key] 
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; } = "User";
        public bool IsContributor { get; set; } = false;
        public bool IsAdmin { get; set; } = false;
        public Profiles Profile { get; set; }
    }
}
