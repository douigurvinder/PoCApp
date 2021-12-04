using PoCApp.Client.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoCApp.Client.Contracts
{
   public interface IPocService
    {
        Task<IEnumerable<IndividualVW>> GetAllIndividualVW(Search filter);
        Task<Individual> GetIndividualByGuid(Guid individualGuid);

        Task<IEnumerable<Country>> GetAllCountries();

    }
}
