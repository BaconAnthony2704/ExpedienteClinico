using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class AnticipoMapping : IEntityTypeConfiguration<clsAnticipo>
    {
        public void Configure(EntityTypeBuilder<clsAnticipo> builder)
        {
            builder.ToTable("tblanticipo").HasKey(a=>a.idAnticipo);
        }
    }
}
