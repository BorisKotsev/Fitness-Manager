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
    public class MemberService
    {
        private ManagerDbContext dbContext;

        public MemberService(ManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<MemberDTO> GetAll()
        {
            return dbContext.Member
                .Select(p => ToDto(p))
                .ToList();
        }

        public void Create(Member member)
        {
            dbContext.Member.Add(member);
            dbContext.SaveChanges();
        }

        public Member GetById(int id)
        {
            return dbContext.Member.FirstOrDefault(x => x.Id == id);
        }

        public void Edit(Member Member)
        {
            Member dbMember = GetById(Member.Id);

            dbMember.FirstName = Member.FirstName;
            dbMember.LastName = Member.LastName;
            dbMember.PhoneNumber = Member.PhoneNumber;
            dbMember.email = Member.email;

            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Member dbMember = GetById(id);
            dbContext.Member.Remove(dbMember);
            dbContext.SaveChanges();
        }

        private static MemberDTO ToDto(Member p)
        {
            MemberDTO Member = new MemberDTO();

            Member.Id = p.Id;
            Member.FirstName = p.FirstName;
            Member.LastName = p.LastName;
            Member.PhoneNumber = p.PhoneNumber;
            Member.email = p.email;

            return Member;
        }
    }
}
