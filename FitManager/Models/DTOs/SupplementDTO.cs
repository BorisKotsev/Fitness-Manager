using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitManager.Models.DTOs
{
    public class SupplementDTO
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public decimal Price { get; set; }

        public string ExpiritionDate { get; set; }

        public string Brand { get; set; }
        public string UserEmail { get; set; }
    }
}
