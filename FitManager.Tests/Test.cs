using FitManager.Models;
using FitManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using FitManager.Models.Entities;
using FitManager.Models.DTOs;

namespace FitManager.Tests
{
    public class Test
    {
        private ManagerDbContext context;
        private MemberService memberService;
        private StaffService staffService;
        private SupplementService supplementService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ManagerDbContext>()
                .UseInMemoryDatabase("TestDb").Options;

            this.context = new ManagerDbContext(options);
            memberService = new MemberService(this.context);
            staffService = new StaffService(this.context);
            supplementService = new SupplementService(this.context);
        }

        [TearDown]
        public void TearDown()
        {
            this.context.Database.EnsureDeleted();
        }


        [Test]
        public void TestGetAll()
        {
            Member member1 = CreateMember(1, "Name");
            Member member2 = CreateMember(2, "Name 2");
            Member member3 = CreateMember(3, "Name 3");

            Staff staff1 = CreateStaff(1, "NAME1");
            Staff staff2 = CreateStaff(2, "NAME2");
            Staff staff3 = CreateStaff(3, "NAME3");

            Supplement supplement1 = CreateSupplement(1, "Kreatin");
            Supplement supplement2 = CreateSupplement(2, "Protein");
            Supplement supplement3 = CreateSupplement(3, "Karnitin");

            memberService.Create(member1);
            memberService.Create(member2);
            memberService.Create(member3);

            staffService.Create(staff1);
            staffService.Create(staff2);
            staffService.Create(staff3);

            supplementService.Create(supplement1);
            supplementService.Create(supplement2);
            supplementService.Create(supplement3);

            List<MemberDTO> memberDTOs = memberService.GetAll();
            List<StaffDTO> staffDTOs = staffService.GetAll();
            List<SupplementDTO> supplementDTOs = supplementService.GetAll();

            Assert.AreEqual(3, memberDTOs.Count);
            Assert.AreEqual(3, staffDTOs.Count);
            Assert.AreEqual(3, supplementDTOs.Count);

            Assert.AreEqual("Name", memberDTOs[0].FirstName);
            Assert.AreEqual("Name 2", memberDTOs[1].FirstName);
            Assert.AreEqual("Name 3", memberDTOs[2].FirstName);

            Assert.AreEqual("NAME1", staffDTOs[0].FirstName);
            Assert.AreEqual("NAME2", staffDTOs[1].FirstName);
            Assert.AreEqual("NAME3", staffDTOs[2].FirstName);

            Assert.AreEqual("Kreatin", supplementDTOs[0].Type);
            Assert.AreEqual("Protein", supplementDTOs[1].Type);
            Assert.AreEqual("Karnitin", supplementDTOs[2].Type);
        }

        [Test]
        public void TestGetById()
        {
            Member member = CreateMember(1, "Name");

            memberService.Create(member);

            Member dbMember = memberService.GetById(1);

            Assert.AreEqual(dbMember.FirstName, "Name");

            Staff staff = CreateStaff(1, "NAME");

            staffService.Create(staff);

            Staff dbStaff = staffService.GetById(1);

            Assert.AreEqual(dbStaff.FirstName, "NAME");

            Supplement supplement = CreateSupplement(1, "Kreatin");

            supplementService.Create(supplement);

            Supplement dbSupplement = supplementService.GetById(1);

            Assert.AreEqual(dbSupplement.Type, "Kreatin");
        }

        [Test]
        public void TestCreate()
        {
            Member member = CreateMember(1, "Name");

            memberService.Create(member);

            Member dbMember = context.Member.FirstOrDefault();

            Assert.NotNull(dbMember);

            Staff staff = CreateStaff(1, "NAME");

            staffService.Create(staff);

            Staff dbStaff = context.Staff.FirstOrDefault();

            Assert.NotNull(dbStaff);

            Supplement supplement = CreateSupplement(1, "Kreatin");

            supplementService.Create(supplement);

            Supplement dbSupplement = context.Supplement.FirstOrDefault();

            Assert.NotNull(dbSupplement);
        }

        [Test]
        public void TestEdit()
        {
            MemberService postService = new MemberService(this.context);

            Member member = new Member();
            member.Id = 1;
            member.FirstName = "Member Name";

            memberService.Create(member);

            Member editMember = new Member();

            editMember.Id = 1;
            editMember.FirstName = "asd";

            postService.Edit(editMember);

            Member dbMember = context.Member.FirstOrDefault(x => x.Id == 1);

            Assert.NotNull(dbMember);
            Assert.AreEqual(dbMember.FirstName, "asd");
        }

        [Test]
        public void TestDelete()
        {
            MemberService memberService = new MemberService(this.context);

            Member Member = new Member();
            Member.Id = 1;
            Member.FirstName = "Member Name";

            memberService.Create(Member);

            memberService.Delete(1);

            Member dbProduct = context.Member.FirstOrDefault(x => x.Id == 1);
            Assert.Null(dbProduct);

            StaffService staffService = new StaffService(this.context);

            Staff staff = new Staff();
            staff.Id = 2;
            staff.FirstName = "Member Name";

            staffService.Create(Staff);

            staffService.Delete(2);

            Staff dbStaff = context.Staff.FirstOrDefault(x => x.Id == 2);
            Assert.Null(dbStaff);

            SupplementService supplementService = new SupplementService(this.context);

            Supplement supplement = new Supplement();
            supplement.Id = 1;
            supplement.Type = "Kreatin";

            supplementService.Create(supplement);

            memberService.Delete(1);

            Supplement dbSupplement = context.Supplement.FirstOrDefault(x => x.Id == 1);
            Assert.Null(dbSupplement);


        }

        private Member CreateMember(int id, string name)
        {
            Member member = new Member();
            member.Id = id;
            member.FirstName = name;

            return member;
        }

        private Staff CreateStaff(int id, string name)
        {
            Staff staff = new Staff();
            staff.Id = id;
            staff.FirstName = name;

            return staff;
        }

        private Supplement CreateSupplement(int id, string type)
        {
            Supplement supplement = new Supplement();
            supplement.Id = id;
            supplement.Type = type;

            return supplement;
        }
    }
}
