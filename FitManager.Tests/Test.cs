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

            Member dbProduct = memberService.GetById(1);

            Assert.AreEqual(dbProduct.FirstName, "Name");

            Staff staff = CreateStaff(1, "NAME");

            staffService.Create(staff);

            Staff dbProduct1 = staffService.GetById(1);

            Assert.AreEqual(dbProduct1.FirstName, "NAME");

            Supplement supplement = CreateSupplement(1, "Kreatin");

            supplementService.Create(supplement);

            Supplement dbProduct2 = supplementService.GetById(1);

            Assert.AreEqual(dbProduct2.Type, "Kreatin");
        }

        [Test]
        public void TestCreate()
        {
            Member member = CreateMember(1, "Name");

            memberService.Create(member);

            Member dbProduct = context.Member.FirstOrDefault();

            Assert.NotNull(dbProduct);

            Staff staff = CreateStaff(1, "NAME");

            staffService.Create(staff);

            Staff dbProduct1 = context.Staff.FirstOrDefault();

            Assert.NotNull(dbProduct1);

            Supplement supplement = CreateSupplement(1, "Kreatin");

            supplementService.Create(supplement);

            Supplement dbProduct2 = context.Supplement.FirstOrDefault();

            Assert.NotNull(dbProduct2);
        }

        [Test]
        public void TestEdit()
        {
            ProductService postService = new ProductService(this.context);

            Product product = new Product();
            product.Id = 1;
            product.Name = "Product Name";
            User user = new User();

            productService.Create(product, user);

            Product editProduct = new Product();

            editProduct.Id = 1;
            editProduct.Name = "asd";

            postService.Edit(editProduct);

            Product dbProduct = context.Products.FirstOrDefault(x => x.Id == 1);

            Assert.NotNull(dbProduct);
            Assert.AreEqual(dbProduct.Name, "asd");
        }

        [Test]
        public void TestDelete()
        {
            ProductService postService = new ProductService(this.context);

            Product product = new Product();
            product.Id = 1;
            product.Name = "Product Name";
            User user = new User();

            productService.Create(product, user);

            productService.Delete(1);

            Product dbProduct = context.Products.FirstOrDefault(x => x.Id == 1);
            Assert.Null(dbProduct);
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
