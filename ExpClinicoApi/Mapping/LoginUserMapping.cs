using ExpClinicoApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpClinicoApi.Mapping
{


    public class LoginUserMapping : IEntityTypeConfiguration<clsLoginUserModel>
    {
        public void Configure(EntityTypeBuilder<clsLoginUserModel> builder)
        {
            builder.ToTable("tbluser").HasKey(t => t.idUser);
        }
    }
}
