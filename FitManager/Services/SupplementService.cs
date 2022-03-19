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
    public class SupplementService
    {
        private ManagerDbContext dbContext;

        public SupplementService(ManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<SupplementDTO> GetAll()
        {
            return dbContext.Supplement
                .Select(p => ToDto(p))
                .ToList();
        }

        public void Create(Supplement product)
        {
            dbContext.Supplement.Add(product);
            dbContext.SaveChanges();
        }

        public Supplement GetById(int id)
        {
            return dbContext.Supplement.FirstOrDefault(x => x.Id == id);
        }

        public void Delete(int id)
        {
            Supplement dbSupplement = GetById(id);
            dbContext.Supplement.Remove(dbSupplement);
            dbContext.SaveChanges();
        }

        private static SupplementDTO ToDto(Supplement p)
        {
            SupplementDTO product = new SupplementDTO();

            product.Id = p.Id;
            product.Type = p.Type;
            product.Price = p.Price;
            product.ExpiritionDate = p.ExpiritionDate;
            product.Brand = p.Brand;

            return product;
        }

    }
}
