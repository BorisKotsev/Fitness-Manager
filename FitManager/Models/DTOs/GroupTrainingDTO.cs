using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitManager.Models.DTOs
{
    public class GroupTrainingDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Date { get; set; }

        public int Duration { get; set; }

        public string TrainerName { get; set; }
    }
}
