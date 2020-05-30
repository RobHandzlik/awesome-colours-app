using System.Linq;
using AwesomeColours.Api.Models;
using AwesomeColours.Service.Extensions;
using AutoMapper;

namespace AwesomeColours.Api.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<DataAccess.Entities.Person, Person>()
                .ForMember(d => d.PersonId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Colours, o => o.MapFrom(s => s.PersonColours.Select(
                        c => new Colour { ColourId = c.Colour.Id, Name = c.Colour.Name, IsEnabled = c.Colour.IsEnabled, IsSelected = true })))
                .ForMember(d => d.IsPalindrome, o => o.MapFrom(s => s.IsFullNamePalindrome()));

            CreateMap<Person, DataAccess.Entities.Person>()
               .ForMember(d => d.Id, o => o.Ignore());

            CreateMap<DataAccess.Entities.Colour, Colour>()
                .ForMember(d => d.ColourId, o => o.MapFrom(s => s.Id));
        }
    }
}
