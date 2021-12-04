using PoCApp.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoCApp.Data.Contracts
{
    public interface ILookupRepository
    {
        public IEnumerable<Country> GetCountries();
        public IEnumerable<Education> GetEducations();


    }
}
