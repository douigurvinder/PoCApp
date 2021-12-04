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
    public class IndividualRepository : PocAppBaseDbContext<Individual, IndividualVW>, IIndividualRepository
    {
        protected override Individual AddEntity(PocAppDbContext entityContext, Individual entity)
        {
            return entityContext.IndividualSet.Add(entity).Entity;
        }

        protected override IEnumerable<Individual> GetEntities(PocAppDbContext entityContext)
        {
            return (from e in entityContext.IndividualSet
                    select e);
        }

        protected override Individual GetEntity(PocAppDbContext entityContext, int id)
        {
            return (from e in entityContext.IndividualSet
                    where e.IndividualId==id
                    select e).FirstOrDefault();
        }

        protected override Individual GetEntity(PocAppDbContext entityContext, Guid guid)
        {
            return (from e in entityContext.IndividualSet
                    where e.IndividualGuid == guid
                    select e).FirstOrDefault();
        }

        protected override IEnumerable<IndividualVW> GetViewEntities(PocAppDbContext entityContext, Search filter)
        {
            return (from e in entityContext.IndividualVWSet
                    //where e.Name.ToLower() == filter.Name.ToLower()
                    select e);

        
        }

        protected override IndividualVW GetViewEntity(PocAppDbContext entityContext, Search filter)
        {
            return (from e in entityContext.IndividualVWSet
                    where e.Name.ToLower() == filter.Name.ToLower()
                    select e).FirstOrDefault();
        }

        protected override IndividualVW GetViewEntity(PocAppDbContext entityContext, int id)
        {
            return (from e in entityContext.IndividualVWSet
                    where e.IndividualId==id
                    select e).FirstOrDefault();
        }
    

        protected override IndividualVW GetViewEntity(PocAppDbContext entityContext, Guid guid)
        {
        return (from e in entityContext.IndividualVWSet
                where e.IndividualGuid == guid
                select e).FirstOrDefault();
    }

        protected override Individual UpdateEntity(PocAppDbContext entityContext, Individual entity)
        {
            return (from e in entityContext.IndividualSet
                    where e.IndividualId == entity.IndividualId
                    select e).FirstOrDefault();
        }
    }
}
