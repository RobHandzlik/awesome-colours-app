using System.Collections.Generic;
using AwesomeColours.DataAccess.Entities;

namespace AwesomeColours.Service
{
    public interface IColourService
    {
        IEnumerable<Colour> GetColours();
        Colour GetColour(int id);
    }
}
