using AwesomeColours.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AwesomeColours.Repository.Data.Mapping
{
    public class PersonMap
    {
        public PersonMap(EntityTypeBuilder<Person> entityBuilder)
        {
            entityBuilder.HasKey(b => b.Id);
            entityBuilder.HasMany(b => b.PersonColours)
                .WithOne(bs => bs.Person)
                .HasForeignKey(bs => bs.PersonId);
            entityBuilder.ToTable("People");
        }
    }
}
