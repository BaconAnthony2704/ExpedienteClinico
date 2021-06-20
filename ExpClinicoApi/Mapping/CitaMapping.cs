using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class CitaMapping : IEntityTypeConfiguration<clsCita>
    {
        public void Configure(EntityTypeBuilder<clsCita> builder)
        {
            builder.ToTable("tblcita").HasKey(c => c.idCita);
        }
    }
}
