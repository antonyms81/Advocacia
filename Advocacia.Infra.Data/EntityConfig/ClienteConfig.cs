using Advocacia.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advocacia.Infra.Data.EntityConfig
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Cliente");

            entityTypeBuilder.HasKey(x => x.Id);

            entityTypeBuilder.Property(x => x.Documento)
               .IsRequired()
               .HasColumnName("Documento")
               .HasColumnType("varchar(14)");


            entityTypeBuilder.Property(x => x.Nome)
              .IsRequired()
              .HasColumnName("Nome")
              .HasColumnType("varchar(50)");

            entityTypeBuilder.Property(x => x.Tipo)
            .IsRequired()
            .HasColumnName("Tipo")
            .HasColumnType("varchar(2)");


            entityTypeBuilder.Property(x => x.Documento)
            .IsRequired()
            .HasColumnName("Documento")
            .HasColumnType("varchar(14)");


            entityTypeBuilder.Property(x => x.DataCadastro)
              .IsRequired()
              .HasColumnName("DataCadastro")
              .HasColumnType("datetime");

            entityTypeBuilder.Property(x => x.Telefone)
            .IsRequired()
            .HasColumnName("Telefone")
            .HasColumnType("varchar(14)");
        }
    }
}
