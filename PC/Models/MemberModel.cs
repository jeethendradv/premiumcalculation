using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PC.Models
{
    public class MemberModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public double Premium { get; set; }
        public List<string> PreConditions { get; set; }
        public List<string> Habits { get; set; }
    }
}