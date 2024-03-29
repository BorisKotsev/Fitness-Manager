﻿using FitManager.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitManager.Models
{
    public class ManagerDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<Member> Member { get; set; }
        public DbSet<Supplement> Supplement { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<GroupTraining> GroupTraining { get; set; }

        public ManagerDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
