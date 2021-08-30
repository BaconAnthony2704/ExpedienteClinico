using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpClinicoApi.Mapping
{
    public class SignosVitalesMapping : IEntityTypeConfiguration<clsSignosVitales>
    {
        public void Configure(EntityTypeBuilder<clsSignosVitales> builder)
        {
            builder.ToTable("tblsignosvitales").HasKey(c=>c.idSignosVitales);
        }
    }
}
