using System.Collections.Generic;
using System.Linq;
using AwesomeColours.DataAccess.Entities;
using AwesomeColours.Repository.Data;
using Microsoft.Extensions.Logging;

namespace AwesomeColours.Service
{
    public class ColourService : IColourService
    {
        private readonly ILogger<ColourService> _logger;
        private readonly IRepository<Colour> _colourRepository;

        public ColourService(
            ILogger<ColourService> logger,
            IRepository<Colour> colourRepository)
        {
            _logger = logger;
            _colourRepository = colourRepository;
        }

        public IEnumerable<Colour> GetColours()
        {
            _logger.LogDebug("Getting data for all Colours.");

            var results = _colourRepository.GetAll();

            _logger.LogDebug($"Received total of {results.Count()} colours.");

            return results;
        }

        public Colour GetColour(int id)
        {
            _logger.LogDebug($"Getting data for ColoursId {id}.");

            return _colourRepository.Get(id).FirstOrDefault();
        }
    }
}
