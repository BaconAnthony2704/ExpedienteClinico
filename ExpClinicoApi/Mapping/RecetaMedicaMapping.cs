using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class RecetaMedicaMapping : IEntityTypeConfiguration<Models.clsRecetaMedicamento>
    {
        void IEntityTypeConfiguration<clsRecetaMedicamento>.Configure(EntityTypeBuilder<clsRecetaMedicamento> builder)
        {
            builder.ToTable("tblreceta_medica").HasKey(e => e.idReceta);
        }
    }
}
