using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{
    public class EmpleadoMapping : IEntityTypeConfiguration<clsEmpleado>
    {
        public void Configure(EntityTypeBuilder<clsEmpleado> builder)
        {
            builder.ToTable("tblempleado").HasKey(e=>e.idEmpleado);
        }
    }
}
