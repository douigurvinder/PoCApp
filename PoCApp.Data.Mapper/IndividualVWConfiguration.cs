using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PoCApp.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoCApp.Data.Mapper
{
    public class IndividualVWConfiguration : IEntityTypeConfiguration<IndividualVW>
    {
        public void Configure(EntityTypeBuilder<IndividualVW> builder)
        {
            builder.ToTable("VW_Individuals");
            builder.HasKey(t=>t.IndividualId);
        }
    }
}
