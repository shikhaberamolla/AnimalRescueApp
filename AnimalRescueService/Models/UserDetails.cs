using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalRescueService.Models
{
    public class UserDetails
    {
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public long? Contact { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
    }
}
