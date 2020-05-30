namespace AwesomeColours.Api.Models
{
    public class Colour
    {
        public int ColourId { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsSelected { get; set; }
        public int Favorited { get; set; }
    }
}
