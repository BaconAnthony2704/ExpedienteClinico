using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class DescuentoMapping : IEntityTypeConfiguration<clsDescuento>
    {
        public void Configure(EntityTypeBuilder<clsDescuento> builder)
        {
            builder.ToTable("tbldescuento").HasKey(d=>d.idDescuento);
        }
    }
}
