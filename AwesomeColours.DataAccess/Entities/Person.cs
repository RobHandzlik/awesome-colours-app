using System.Collections.Generic;

namespace AwesomeColours.DataAccess.Entities
{
    public class Person : BaseAuditClass
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsAuthorised { get; set; }
        public bool IsValid { get; set; }
        public bool IsEnabled { get; set; }        

        public ICollection<PersonColour> PersonColours { get; set; }
    }
}
