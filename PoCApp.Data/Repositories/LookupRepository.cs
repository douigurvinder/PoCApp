using PoCApp.Business.Entities;
using PoCApp.Data.Contracts;
using PoCApp.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoCApp.Data.Repositories
{
    public class LookupRepository : ILookupRepository
    {

        PocAppDbContext ctx;
        public LookupRepository()
        {
            ctx = new PocAppDbContext();
        }

        public IEnumerable<Country> GetCountries()
        {
            return (from e in ctx.CountrySet
                    select e);
        }

        public IEnumerable<Education> GetEducations()
        {
            return (from e in ctx.EducationSet
                    select e);
        }
    }
}
