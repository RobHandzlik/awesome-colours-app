namespace AwesomeColours.DataAccess.Entities
{
    public class PersonColour : BaseAuditClass
    {
        public int PersonId { get; set; }
        public Person Person { get; set; }

        public int ColourId { get; set; }
        public Colour Colour { get; set; }
    }
}
