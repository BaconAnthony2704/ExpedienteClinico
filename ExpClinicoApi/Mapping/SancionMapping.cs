using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class SancionMapping : IEntityTypeConfiguration<clsSancion>
    {
        public void Configure(EntityTypeBuilder<clsSancion> builder)
        {
            builder.ToTable("tblsancion").HasKey(s=>s.idSancion);
        }
    }
}
