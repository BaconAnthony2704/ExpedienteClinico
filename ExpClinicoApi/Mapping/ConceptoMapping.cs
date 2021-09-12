using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class ConceptoMapping : IEntityTypeConfiguration<clsConcepto>
    {
        public void Configure(EntityTypeBuilder<clsConcepto> builder)
        {
            builder.ToTable("tblconcepto").HasKey(c => c.IdConcepto);
        }
    }
}
