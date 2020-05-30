using System;
using System.Collections.Generic;
using System.Linq;
using AwesomeColours.Api.Models;
using AwesomeColours.Service;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AwesomeColours.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColoursController : ControllerBase
    {
        private readonly ILogger<ColoursController> _logger;
        private readonly IMapper _mapper;
        private readonly IColourService _colourService;
        private readonly IPersonDetailsService _personDetailsService;

        public ColoursController(
            ILogger<ColoursController> logger,
            IMapper mapper,
            IColourService colourService,
            IPersonDetailsService personDetailsService)
        {
            _logger = logger;
            _mapper = mapper;
            _colourService = colourService;
            _personDetailsService = personDetailsService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _logger.LogDebug("Getting all Colours from service.");

                var entities = _colourService.GetColours();
                var models = _mapper.Map<IEnumerable<Colour>>(entities).ToList();

                // Add Favorited times data
                models.ForEach(colour => 
                    colour.Favorited = _personDetailsService.FavoritedCountForColourId(colour.ColourId));

                _logger.LogInformation($"Returning total of {models.Count()} mapped models to caller.");
                return Ok(models);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occurred in ColoursController.Get: {ex}");
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                _logger.LogDebug($"Getting Colour id [{id}] data from service.");

                var entity = _colourService.GetColour(id);
                var model = _mapper.Map<Colour>(entity);

                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occurred in ColoursController.Get for id {id}: {ex}");
                return StatusCode(500, ex.ToString());
            }
        }
    }
}
