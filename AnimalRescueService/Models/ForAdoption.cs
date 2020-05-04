using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalRescueService.Models
{
    public class ForAdoption
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Age { get; set; }
        public string AnimalType { get; set; }
        public string Description { get; set; }
    }
}
