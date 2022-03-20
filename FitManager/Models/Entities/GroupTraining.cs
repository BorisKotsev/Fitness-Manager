using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FitManager.Models.Entities
{
    public class GroupTraining
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public int Duration { get; set; }
        public string TrainerName { get; set; }

    }
}
