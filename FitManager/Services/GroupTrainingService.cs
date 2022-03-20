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
    public class GroupTrainingService
    {
        private ManagerDbContext dbContext;

        public GroupTrainingService(ManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<GroupTrainingDTO> GetAll()
        {
            return dbContext.GroupTraining
                .Select(p => ToDto(p))
                .ToList();
        }

        public GroupTraining GetById(int id)
        {
            return dbContext.GroupTraining.FirstOrDefault(x => x.Id == id);
        }

        public void Delete(int id)
        {
            GroupTraining dbTraining = GetById(id);
            dbContext.GroupTraining.Remove(dbTraining);
            dbContext.SaveChanges();
        }

        public void Create(GroupTraining groupTraining)
        {
            dbContext.GroupTraining.Add(groupTraining);
            dbContext.SaveChanges();
        }

        public void Edit(GroupTraining groupTraining)
        {
            GroupTraining dbTraining = GetById(groupTraining.Id);

            dbTraining.Date = groupTraining.Date;

            dbContext.SaveChanges();
        }

        private static GroupTrainingDTO ToDto(GroupTraining p)
        {
            GroupTrainingDTO grouptraining = new GroupTrainingDTO();

            grouptraining.Id = p.Id;
            grouptraining.Name = p.Name;
            grouptraining.Date = p.Date;
            grouptraining.Duration = p.Duration;
            grouptraining.TrainerName = p.TrainerName;

            return grouptraining;
        }
    }
}
