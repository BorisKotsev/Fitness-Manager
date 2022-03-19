using FitManager.Models.DTOs;
using FitManager.Models.Entities;
using FitManager.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitManager.Controllers
{
    public class SupplementController : Controller
    {
        private SupplementService supplementService;
      

        public SupplementController(SupplementService supplementService)
        {
            this.supplementService = supplementService;
        
        }

        public IActionResult Index()
        {
            List<SupplementDTO> products = supplementService.GetAll();

            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Supplement product)
        {

            supplementService.Create(product);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            Supplement supplement = supplementService.GetById(id);
            return View(supplement);
        }
        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            supplementService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
