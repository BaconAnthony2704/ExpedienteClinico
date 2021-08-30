using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class RecetaMapping : IEntityTypeConfiguration<clsReceta>
    {
        public void Configure(EntityTypeBuilder<clsReceta> builder)
        {
            builder.ToTable("tblreceta").HasKey(e => e.idReceta);
        }
    }
}
