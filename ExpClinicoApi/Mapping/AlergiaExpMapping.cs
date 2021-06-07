using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class AlergiaExpMapping : IEntityTypeConfiguration<pivoteAlergiaExp>
    {
        public void Configure(EntityTypeBuilder<pivoteAlergiaExp> builder)
        {
            builder.ToTable("tblalergia_expediente").HasKey(e => e.idAlergia);
        }

    }
}
