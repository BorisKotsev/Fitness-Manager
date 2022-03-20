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
    public class GroupTrainingController : Controller
    {
        private GroupTrainingService groupTrainingService;

        public GroupTrainingController(GroupTrainingService groupTrainingService)
        {
            this.groupTrainingService = groupTrainingService;
        }

        public IActionResult Index()
        {
            List<GroupTrainingDTO> groupTraining = groupTrainingService.GetAll();

            return View(groupTraining);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GroupTraining groupTraining)
        {
            groupTrainingService.Create(groupTraining);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditDate(int id)
        {
            GroupTraining groupTraining = groupTrainingService.GetById(id);

            return View(groupTraining);
        }

        [HttpPost]
        public IActionResult Edit(GroupTraining groupTraining)
        {
            groupTrainingService.EditDate(groupTraining);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            GroupTraining groupTraining = groupTrainingService.GetById(id);
            return View(groupTraining);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            groupTrainingService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
