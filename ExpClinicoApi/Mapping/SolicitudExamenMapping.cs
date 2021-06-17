using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class SolicitudExamenMapping : IEntityTypeConfiguration<clsSolicitudExamen>
    {
        public void Configure(EntityTypeBuilder<clsSolicitudExamen> builder)
        {
            builder.ToTable("tblsolicitudexamen").HasKey(s => s.idSolicitudExamen);
        }
    }
}
