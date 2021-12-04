using Core.Common.Data;
using PoCApp.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoCApp.Data.Helpers
{
    public abstract class PocAppBaseDbContext<T, VW> : CoreRepository<T, VW, Search, PocAppDbContext>
        where T : class, new()
        where VW : class, new()

    {
    }
}
