using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AwesomeColours.DataAccess.Entities;
using AwesomeColours.Repository.Data;
using Moq;
using NUnit.Framework;

namespace AwesomeColours.Service.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class PersonDetailsServiceTests
    {
        private IPersonDetailsService _personDetailsService;
        private Mock<IRepository<Person>> _mockedPersonRepository;

        [SetUp]
        public void Init()
        {
            _mockedPersonRepository = new Mock<IRepository<Person>>();
            _personDetailsService = new PersonDetailsService(
                _mockedPersonRepository.Object);
        }

        [Test]
        public void GetAllPersonDetials_Success()
        {
            // Arrange
            IQueryable<Person> testData = GetTestData();

            _mockedPersonRepository.Setup(x => x.GetAll()).Returns(testData);

            // Act
            var result = _personDetailsService.GetAllPersonDetials().ToList();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count);
            Assert.AreEqual("AAA", result[0].FirstName);
            Assert.AreEqual(1, result[0].PersonColours.FirstOrDefault().ColourId);
        }

        [Test]
        public void GetPersonDetails_Success()
        {
            // Arrange
            var personId = 1;
            IQueryable<Person> testData = GetTestData();

            _mockedPersonRepository.Setup(x => x.Get(personId)).Returns(testData.Where(e => e.Id == personId));

            // Act
            var result = _personDetailsService.GetPersonDetails(personId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("AAA", result.FirstName);
            Assert.AreEqual(1, result.PersonColours.FirstOrDefault().ColourId);
        }

        [Test]
        public void FavoritedCountForColourId_Success()
        {
            // Arrange
            var colourId = 1;
            IQueryable<Person> testData = GetTestData();

            _mockedPersonRepository.Setup(x => x.GetAll()).Returns(testData);

            // Act
            var result = _personDetailsService.FavoritedCountForColourId(colourId);

            // Assert
            Assert.AreEqual(2, result);
        }


        #region Helpers

        private static IQueryable<Person> GetTestData()
        {
            return new List<Person>
            {
                new Person { Id = 1, FirstName = "AAA", LastName = "AA", IsEnabled = true, IsValid = true, IsAuthorised = true, PersonColours = new List<PersonColour> { new PersonColour { ColourId = 1} }},
                new Person { Id = 2, FirstName = "BBB", LastName = "BB", IsEnabled = true, IsValid = true, IsAuthorised = true, PersonColours = new List<PersonColour> { new PersonColour { ColourId = 2} }},
                new Person { Id = 3, FirstName = "CCC", LastName = "CC", IsEnabled = true, IsValid = true, IsAuthorised = true, PersonColours = new List<PersonColour> { new PersonColour { ColourId = 3} }},
                new Person { Id = 4, FirstName = "DD", LastName = "DD", IsEnabled = true, IsValid = true, IsAuthorised = true, PersonColours = new List<PersonColour> { new PersonColour { ColourId = 1} }}
            }.AsQueryable();
        }

        #endregion

    }
}
