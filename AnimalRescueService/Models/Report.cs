using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalRescueService.Models
{
    public class Report
    {
        public int ReportId { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public string Animal { get; set; }
    }
}
