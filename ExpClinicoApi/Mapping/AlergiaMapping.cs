using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class AlergiaMapping : IEntityTypeConfiguration<clsAlergia>
    {
        public void Configure(EntityTypeBuilder<clsAlergia> builder)
        {
            builder.ToTable("tblalergia").HasKey(e => e.idAlergia);
        }
    }
}
