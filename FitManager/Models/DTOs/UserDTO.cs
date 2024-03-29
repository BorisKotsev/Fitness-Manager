﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitManager.Models.DTOs
{
    public class UserDTO
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
        public int Duration { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
