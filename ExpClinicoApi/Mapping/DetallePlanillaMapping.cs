using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class DetallePlanillaMapping : IEntityTypeConfiguration<clsDetallePlanilla>
    {
        public void Configure(EntityTypeBuilder<clsDetallePlanilla> builder)
        {
            builder.ToTable("tbldetalleplanilla").HasKey(e => e.idDetallePlanilla);
        }
    }
}
