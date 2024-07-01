﻿// <auto-generated />
using System;
using Advocacia.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Advocacia.Infra.Data.Migrations
{
    [DbContext(typeof(AdvocaciaContext))]
    partial class AdvocaciaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Advocacia.Domain.Entities.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime")
                        .HasColumnName("DataCadastro");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("varchar(14)")
                        .HasColumnName("Documento");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Nome");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(14)")
                        .HasColumnName("Telefone");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("varchar(2)")
                        .HasColumnName("Tipo");

                    b.HasKey("Id");

                    b.ToTable("Cliente", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}