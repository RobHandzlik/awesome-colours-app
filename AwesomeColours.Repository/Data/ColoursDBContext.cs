using AwesomeColours.DataAccess.Entities;
using AwesomeColours.Repository.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace AwesomeColours.Repository.Data
{
    public class ColoursDBContext : DbContext
    {
        public ColoursDBContext(DbContextOptions<ColoursDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new PersonMap(modelBuilder.Entity<Person>());
            new ColourMap(modelBuilder.Entity<Colour>());
            modelBuilder.Entity<PersonColour>().HasKey(pc => new { pc.PersonId, pc.ColourId });

            #region Seed test data
            
            modelBuilder.Entity<Person>().HasData(
                new Person { Id = 1, FirstName = "Willis", LastName = "Tibbs", IsAuthorised = false , IsValid = true, IsEnabled = false},
                new Person { Id = 2, FirstName = "Sharon", LastName = "Halt", IsAuthorised = false, IsValid = false, IsEnabled = false },
                new Person { Id = 3, FirstName = "Patrick", LastName = "Kerr", IsAuthorised = false, IsValid = true, IsEnabled = true },
                new Person { Id = 4, FirstName = "Lilly", LastName = "Hale", IsAuthorised = false, IsValid = false, IsEnabled = false },
                new Person { Id = 5, FirstName = "Joel", LastName = "Daly", IsAuthorised = false, IsValid = true, IsEnabled = true },
                new Person { Id = 6, FirstName = "Imogen", LastName = "Kent", IsAuthorised = false, IsValid = false, IsEnabled = true },
                new Person { Id = 7, FirstName = "George", LastName = "Edwards", IsAuthorised = false, IsValid = true, IsEnabled = true },
                new Person { Id = 8, FirstName = "Gabriel", LastName = "Franics", IsAuthorised = false, IsValid = false, IsEnabled = false },
                new Person { Id = 9, FirstName = "Courtney", LastName = "Arnold", IsAuthorised = false, IsValid = true, IsEnabled = true },
                new Person { Id = 10, FirstName = "Brian", LastName = "Allen", IsAuthorised = false, IsValid = true, IsEnabled = true },
                new Person { Id = 11, FirstName = "Bo", LastName = "Bob", IsAuthorised = true, IsValid = true, IsEnabled = true }
                );

            modelBuilder.Entity<Colour>().HasData(
                new Colour { Id = 1, Name = "Red", IsEnabled = true },
                new Colour { Id = 2, Name = "Green", IsEnabled = true },
                new Colour { Id = 3, Name = "Blue", IsEnabled = true }
                );

            modelBuilder.Entity<PersonColour>().HasData(
               new PersonColour { PersonId = 1, ColourId = 1 },
               new PersonColour { PersonId = 1, ColourId = 2 },
               new PersonColour { PersonId = 1, ColourId = 3 },
               new PersonColour { PersonId = 2, ColourId = 1 },
               new PersonColour { PersonId = 2, ColourId = 2 },
               new PersonColour { PersonId = 2, ColourId = 3 },
               new PersonColour { PersonId = 3, ColourId = 2 },
               new PersonColour { PersonId = 4, ColourId = 1 },
               new PersonColour { PersonId = 4, ColourId = 2 },
               new PersonColour { PersonId = 4, ColourId = 3 },
               new PersonColour { PersonId = 5, ColourId = 2 },
               new PersonColour { PersonId = 6, ColourId = 1 },
               new PersonColour { PersonId = 7, ColourId = 2 },
               new PersonColour { PersonId = 7, ColourId = 3 },
               new PersonColour { PersonId = 8, ColourId = 2 },
               new PersonColour { PersonId = 9, ColourId = 1 },
               new PersonColour { PersonId = 10, ColourId = 1 },
               new PersonColour { PersonId = 10, ColourId = 2 },
               new PersonColour { PersonId = 10, ColourId = 3 },
               new PersonColour { PersonId = 11, ColourId = 1 }
               );

            #endregion
        }

        public DbSet<Colour> Colours { get; set; }
        public DbSet<Person> Peoples { get; set; }
        public DbSet<PersonColour> PersonColours { get; set; }
    }
}
