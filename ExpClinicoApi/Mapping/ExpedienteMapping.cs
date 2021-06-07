using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class ExpedienteMapping : IEntityTypeConfiguration<clsExpediente>
    {
        public void Configure(EntityTypeBuilder<clsExpediente> builder)
        {
            builder.ToTable("tblexpediente").HasKey(e => e.idExpediente);
        }
    }
}
