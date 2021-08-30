using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class ConsultaMapping : IEntityTypeConfiguration<clsConsulta>
    {
        public void Configure(EntityTypeBuilder<clsConsulta> builder)
        {
            builder.ToTable("tblconsulta").HasKey(e => e.idConsulta);
        }
    }
}
