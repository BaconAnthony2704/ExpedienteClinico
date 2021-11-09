using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExpClinicoApi.Mapping
{
    public class TransaccionMedicamentoMapping: IEntityTypeConfiguration<clsTransacionMedicamento>
    {
        void IEntityTypeConfiguration<clsTransacionMedicamento>.Configure(EntityTypeBuilder<clsTransacionMedicamento> builder)
        {
            builder.ToTable("tbltransaccion_medicamento").HasKey(e => e.idTransaccionMedicamento);
        }
    }
}
