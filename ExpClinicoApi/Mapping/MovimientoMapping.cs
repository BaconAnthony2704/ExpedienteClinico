using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class MovimientoMapping : IEntityTypeConfiguration<clsMovimiento>
    {
        public void Configure(EntityTypeBuilder<clsMovimiento> builder)
        {
            builder.ToTable("tblMovimiento").HasKey(m => m.IdMovimiento);
        }
    }
}
