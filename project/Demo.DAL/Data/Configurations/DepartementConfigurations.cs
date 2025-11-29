using Demo.DAL.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Data.Configurations
{
    internal class DepartementConfigurations:IEntityTypeConfiguration<Departement>
    {
        public void Configure(EntityTypeBuilder<Departement> builder)
        {
            builder.Property(D => D.Id).UseIdentityColumn(10, 10);

            builder.HasMany(e => e.Employees)
                .WithOne(d => d.Departement);

        }
    }
}
