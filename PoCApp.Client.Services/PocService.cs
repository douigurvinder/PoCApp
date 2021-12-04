using PoCApp.Client.Contracts;
using PoCApp.Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoCApp.Client.Services
{
    public class PocService : IPocService
    {
        private readonly IHttpService _httpService;

        public PocService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            return await _httpService.GetEntities<Country>("api/pocs/GetAllCountries");
        }

        public async Task<IEnumerable<IndividualVW>> GetAllIndividualVW(Search filter)
        {
            return await _httpService.GetFilteredEntities<IndividualVW>("api/pocs/GetFilteredIndividuals", filter);
        }

        public Task<Individual> GetIndividualByGuid(Guid individualGuid)
        {
            throw new NotImplementedException();
        }
    }
}
