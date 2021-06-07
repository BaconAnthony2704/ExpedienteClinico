using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class HistorialMedicoMapping : IEntityTypeConfiguration<clsHistorialMedico>
    {
        public void Configure(EntityTypeBuilder<clsHistorialMedico> builder)
        {
            builder.ToTable("tblhistorialmedico").HasKey(e => e.idHistorialMedico);
        }
    }
}
