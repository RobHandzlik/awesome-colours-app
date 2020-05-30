using System.Collections.Generic;

namespace AwesomeColours.Api.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAuthorised { get; set; }
        public bool IsValid { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsPalindrome { get; set; }

        public IEnumerable<Colour> Colours { get; set; }
    }
}
