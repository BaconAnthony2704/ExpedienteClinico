using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class PermisoMapping : IEntityTypeConfiguration<clsPermiso>
    {
        public void Configure(EntityTypeBuilder<clsPermiso> builder)
        {
            builder.ToTable("tblpermiso").HasKey(p => p.idPermiso);
        }
    }
}
