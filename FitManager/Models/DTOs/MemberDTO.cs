﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitManager.Models.DTOs
{
    public class MemberDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int PhoneNumber { get; set; }

        public string email { get; set; }
    }
}
