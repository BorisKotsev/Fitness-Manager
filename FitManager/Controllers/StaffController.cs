using FitManager.Models.DTOs;
using FitManager.Models.Entities;
using FitManager.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitManager.Controllers
{
    public class StaffController : Controller
    {
        private StaffService staffService;

        public StaffController(StaffService staffService)
        {
            this.staffService = staffService; 
        }

        public IActionResult Index()
        {
            List<StaffDTO> staff = staffService.GetAll();

            return View(staff);
        }
    }
}
