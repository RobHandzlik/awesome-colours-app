using System.Collections.Generic;

namespace AwesomeColours.DataAccess.Entities
{
    public class Colour : BaseAuditClass
    {
        public string Name { get; set; }
        public bool IsEnabled { get; set; }

        public ICollection<PersonColour> PersonColours { get; set; }
    }
}
