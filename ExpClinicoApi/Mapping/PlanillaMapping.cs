using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class PlanillaMapping : IEntityTypeConfiguration<clsPlanilla>
    {
        public void Configure(EntityTypeBuilder<clsPlanilla> builder)
        {
            builder.ToTable("tblplanilla").HasKey(e => e.idPlanilla);
        }
    }
}
