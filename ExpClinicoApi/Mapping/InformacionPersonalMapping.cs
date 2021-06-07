using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class InformacionPersonalMapping : IEntityTypeConfiguration<clsInformacionPersonal>
    {
        public void Configure(EntityTypeBuilder<clsInformacionPersonal> builder)
        {
            builder.ToTable("tblinformacionpersonal").HasKey(e => e.idInformacionPersonal);
        }
    }
}
