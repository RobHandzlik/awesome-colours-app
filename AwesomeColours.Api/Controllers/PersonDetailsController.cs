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
    public class PersonDetailsController : ControllerBase
    {
        private readonly ILogger<PersonDetailsController> _logger;
        private readonly IMapper _mapper;
        private readonly IPersonDetailsService _personDetailsService;

        public PersonDetailsController(
            ILogger<PersonDetailsController> logger, 
            IMapper mapper, 
            IPersonDetailsService personDetailsService)
        {
            _logger = logger;
            _mapper = mapper;
            _personDetailsService = personDetailsService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                _logger.LogDebug("Getting all People data from service.");

                var entities = _personDetailsService.GetAllPersonDetials();
                var models = _mapper.Map<IEnumerable<Person>>(entities);

                _logger.LogInformation($"Returning total of {models.Count()} mapped models to caller.");
                return Ok(models);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occurred in PersonDetailsController.Get: {ex}");
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                _logger.LogDebug($"Getting Person id [{id}] data from service.");

                var entity = _personDetailsService.GetPersonDetails(id);
                var model = _mapper.Map<Person>(entity);

                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occurred in PersonDetailsController.Get for id {id}: {ex}");
                return StatusCode(500, ex.ToString());
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person request)
        {
            try
            {
                _logger.LogDebug($"Revived request to update Person id [{request.PersonId}] data.");

                var entity = _personDetailsService.GetPersonDetails(request.PersonId);
                if (entity == null)
                {
                    return NotFound($"Person with id [{request.PersonId}] not found.");
                }

                var updatedEntity = _mapper.Map(request, entity);

                foreach (var colour in request.Colours.ToList())
                {
                    var personColour = updatedEntity.PersonColours.FirstOrDefault(e => e.ColourId == colour.ColourId);
                    if (personColour == null && colour.IsSelected)
                    {
                        // Add new colour
                        updatedEntity.PersonColours.Add(
                            new DataAccess.Entities.PersonColour { PersonId = request.PersonId, ColourId = colour.ColourId });
                    }
                    else if (personColour != null && !colour.IsSelected)
                    {
                        // Remove deselected colour
                        updatedEntity.PersonColours.Remove(personColour);
                    }
                }

                _personDetailsService.UpdatePersonDetails(updatedEntity);

                return Ok(updatedEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception occurred in PersonDetailsController.Post for id {request.PersonId}: {ex}");
                return StatusCode(500, ex.ToString());
            }
        }
    }
}
