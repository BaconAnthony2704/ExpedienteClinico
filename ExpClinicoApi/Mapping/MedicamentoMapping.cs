using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class MedicamentoMapping : IEntityTypeConfiguration<clsMedicamento>
    {
        public void Configure(EntityTypeBuilder<clsMedicamento> builder)
        {
            builder.ToTable("tblmedicamento").HasKey(e => e.IDMEDICAMENTO);
        }
    }
}
