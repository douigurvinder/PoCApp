using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PoCApp.Business.Entities;
using PoCApp.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PoCApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PocsController : ControllerBase
    {
        private readonly IIndividualRepository _individualRepository;
        private readonly ILookupRepository _lookupRepository;

        public PocsController(IIndividualRepository individualRepository, ILookupRepository lookupRepository)
        {
            _individualRepository = individualRepository;
            _lookupRepository = lookupRepository;
        }

        [HttpPost("GetFilteredIndividuals")]
        public IEnumerable<IndividualVW> GetIndividuals(Search filter)
        {
            return _individualRepository.GetVwEntities(filter);
        }

  


        [HttpGet("GetIndividualByGuid/{individualGuid}")]
        public IndividualVW GetIndividuals(Guid individualGuid)
        {
            return _individualRepository.GetVwEntity(individualGuid);
        }
        [HttpPost("SaveIndividual")]
        public Individual SaveIndividual(Individual individual)
        {

            if (individual.IndividualId == 0)
            {
                return _individualRepository.Add(individual);
            }
            else
            {
                return _individualRepository.Update(individual);
            }

        }

        [HttpGet("GetAllCountries")]
        public IEnumerable<Country> GetAllCountries()
        {

            return _lookupRepository.GetCountries();
        }


    }
}
