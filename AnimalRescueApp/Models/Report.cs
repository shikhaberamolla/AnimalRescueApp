using System;
using System.Collections.Generic;

namespace AnimalRescueApp.Models
{
    public partial class Report
    {
        public int ReportId { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public string Animal { get; set; }
    }
}
