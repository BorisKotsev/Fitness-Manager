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
    public class MemberController : Controller
    {
        private MemberService memberService;

        public MemberController(MemberService memberService)
        {
            this.memberService = memberService;
        }

        public IActionResult Index()
        {
            List<MemberDTO> members = memberService.GetAll();

            return View(members);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Member member)
        {
            memberService.Create(member);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            Member member = memberService.GetById(id);

            return View(member);
        }

        [HttpPost]
        public IActionResult Edit(Member member)
        {
            memberService.Edit(member);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Member member = memberService.GetById(id);
            return View(member);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int id)
        {
            memberService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
