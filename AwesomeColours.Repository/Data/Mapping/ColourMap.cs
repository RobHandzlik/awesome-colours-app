using AwesomeColours.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AwesomeColours.Repository.Data.Mapping
{
    public class ColourMap
    {
        public ColourMap(EntityTypeBuilder<Colour> entityBuilder)
        {
            entityBuilder.HasKey(b => b.Id);
            entityBuilder.HasMany(b => b.PersonColours)
                .WithOne(bs => bs.Colour)
                .HasForeignKey(bs => bs.ColourId);
            entityBuilder.ToTable("Colours");
        }
    }
}
