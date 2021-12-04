using Core.Common.Contracts;
using PoCApp.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoCApp.Data.Contracts
{
  public  interface IIndividualRepository: ICoreRepository<Individual, IndividualVW,Search>
    {
    }
}
