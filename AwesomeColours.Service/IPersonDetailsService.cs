using System.Collections.Generic;
using AwesomeColours.DataAccess.Entities;

namespace AwesomeColours.Service
{
    public interface IPersonDetailsService
    {
        IEnumerable<Person> GetAllPersonDetials();
        Person GetPersonDetails(int id);
        void UpdatePersonDetails(Person person);
        int FavoritedCountForColourId(int colourId);
    }
}
