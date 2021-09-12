using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class DetalleMovimientoMapping : IEntityTypeConfiguration<clsDetalleMovimiento>
    {
        public void Configure(EntityTypeBuilder<clsDetalleMovimiento> builder)
        {
            builder.ToTable("tbldetallemovimiento").HasKey(d => d.IdDetalleMovimiento);
        }
    }
}
