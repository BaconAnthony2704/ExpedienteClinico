using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class ExploracionFisicaMapping : IEntityTypeConfiguration<clsExploracionFisica>
    {
        public void Configure(EntityTypeBuilder<clsExploracionFisica> builder)
        {
            builder.ToTable("tblexploracionfisica").HasKey(e => e.idExploracionFisica);
        }
    }
}
