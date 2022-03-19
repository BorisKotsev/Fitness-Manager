using FitManager.Models;
using FitManager.Models.DTOs;
using FitManager.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitManager.Services
{
    public class StaffService
    {
        private ManagerDbContext dbContext;

        public StaffService(ManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        private static StaffDTO ToDto(Staff s)
        {
            StaffDTO staff = new StaffDTO();

            staff.Id = s.Id;
            staff.FirstName = s.FirstName;
            staff.LastName = s.LastName;
            staff.PhoneNumber = s.PhoneNumber;

            return staff;
        }

        public List<StaffDTO> GetAll()
        {
            return dbContext.Staff
                .Select(p => ToDto(p))
                .ToList();
        }
    }
}
