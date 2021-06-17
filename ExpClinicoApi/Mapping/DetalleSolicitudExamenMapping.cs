using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class DetalleSolicitudExamenMapping : IEntityTypeConfiguration<clsDetalleSolicitudExamen>
    {
        public void Configure(EntityTypeBuilder<clsDetalleSolicitudExamen> builder)
        {
            builder.ToTable("tbldetallesolicitudexamen").HasKey(d => d.idDetalleSolicitudExamen);
        }
    }
}
