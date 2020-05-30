using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AwesomeColours.DataAccess.Entities;
using AwesomeColours.Repository.Data;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace AwesomeColours.Service.Tests
{
    [TestFixture]
    [ExcludeFromCodeCoverage]
    public class ColourServiceTests
    {
        private IColourService _colourService;

        private Mock<ILogger<ColourService>> _mockedLogger;
        private Mock<IRepository<Colour>> _mockedColourRepository;

        [SetUp]
        public void Init()
        {
            _mockedLogger = new Mock<ILogger<ColourService>>();
            _mockedColourRepository = new Mock<IRepository<Colour>>();

            _colourService = new ColourService(
                _mockedLogger.Object,
                _mockedColourRepository.Object);
        }

        [Test]
        public void GetColours_Success()
        {
            // Arrange
            IQueryable<Colour> testData = GetTestData();

            _mockedColourRepository.Setup(x => x.GetAll()).Returns(testData);

            // Act
            var result = _colourService.GetColours().ToList();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("AAA", result[0].Name);
        }

        [Test]
        public void GetColour_Success()
        {
            // Arrange
            var colourId = 1;
            IQueryable<Colour> testData = GetTestData();

            _mockedColourRepository.Setup(x => x.Get(colourId)).Returns(testData.Where(e => e.Id == colourId));

            // Act
            var result = _colourService.GetColour(colourId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("AAA", result.Name);
        }


        #region Helpers

        private static IQueryable<Colour> GetTestData()
        {
            return new List<Colour>
            {
                new Colour { Id = 1, Name = "AAA", IsEnabled = true },
                new Colour { Id = 2, Name = "BBB", IsEnabled = true },
                new Colour { Id = 3, Name = "CCC", IsEnabled = true }
            }.AsQueryable();
        }

        #endregion

    }
}
