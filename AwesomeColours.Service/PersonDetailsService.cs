using System.Collections.Generic;
using System.Linq;
using AwesomeColours.DataAccess.Entities;
using AwesomeColours.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace AwesomeColours.Service
{
    public class PersonDetailsService : IPersonDetailsService
    {
        private readonly IRepository<Person> _personRepository;

        public PersonDetailsService(IRepository<Person> personRepository)
        {
            _personRepository = personRepository;
        }

        public IEnumerable<Person> GetAllPersonDetials()
        {
            return _personRepository.GetAll()
                .Include(e => e.PersonColours)
                .ThenInclude(e => e.Colour)
                .AsNoTracking();
        }

        public Person GetPersonDetails(int id)
        {
            return _personRepository.Get(id)
                .Include(e => e.PersonColours)
                .ThenInclude(e => e.Colour)
                .FirstOrDefault();
        }

        public void UpdatePersonDetails(Person person)
        {
            _personRepository.Update(person);
        }

        public int FavoritedCountForColourId(int colourId)
        {
            return GetAllPersonDetials()
                .SelectMany(e => e.PersonColours
                .Where(c => c.ColourId == colourId)
                .Select(c => c.Colour))
                .Count();
        }
    }
}
