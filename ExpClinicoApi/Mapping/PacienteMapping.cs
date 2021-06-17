using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class PacienteMapping : IEntityTypeConfiguration<clsPaciente>
    {
        public void Configure(EntityTypeBuilder<clsPaciente> builder)
        {
            builder.ToTable("tblpaciente").HasKey(p => p.idPaciente);
        }
    }
}
