using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class ExamenMapping : IEntityTypeConfiguration<clsExamen>
    {
        public void Configure(EntityTypeBuilder<clsExamen> builder)
        {
            builder.ToTable("tblexamen").HasKey(e => e.idExamen);
        }
    }
}
