using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class AsistenciaLaboralMapping : IEntityTypeConfiguration<clsAsistenciaLaboral>
    {
        public void Configure(EntityTypeBuilder<clsAsistenciaLaboral> builder)
        {
            builder.ToTable("tblasistencialaboral").HasKey(a=>a.idAsistenciaLaboral);
        }
    }
}
