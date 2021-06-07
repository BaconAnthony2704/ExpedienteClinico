using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class InformacionAdicionalMapping : IEntityTypeConfiguration<clsInformacionAdicional>
    {
       

        public void Configure(EntityTypeBuilder<clsInformacionAdicional> builder)
        {
            builder.ToTable("tblinformacionadicional").HasKey(c => c.idInformacionAdicional);
        }
    }
}
