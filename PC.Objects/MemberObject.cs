using System.Collections.Generic;

namespace PC.Objects
{
    public class MemberObject
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public double Premium { get; set; }
        public List<string> PreConditions { get; set; }
        public List<string> Habits { get; set; }
    }
}
