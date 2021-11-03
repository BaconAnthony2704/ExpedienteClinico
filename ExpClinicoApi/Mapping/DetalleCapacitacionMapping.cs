using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class DetalleCapacitacionMapping : IEntityTypeConfiguration<clsDetalleCapacitacion>
    {
        public void Configure(EntityTypeBuilder<clsDetalleCapacitacion> builder)
        {
            builder.ToTable("tbldetallecapacitacion").HasKey(d=>d.idDetalleCapacitacion);
        }
    }
}
