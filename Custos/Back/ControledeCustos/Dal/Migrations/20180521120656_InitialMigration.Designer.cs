﻿// <auto-generated />
using Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Dal.Migrations
{
    [DbContext(typeof(CustosContexto))]
    [Migration("20180521120656_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Model.Departamento", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Codigo");

                    b.ToTable("Departamento");
                });

            modelBuilder.Entity("Model.Funcionario", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Codigo");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("Model.FuncionarioDepartamentos", b =>
                {
                    b.Property<int>("CodigoFuncionario");

                    b.Property<int>("CodigoDepartamento");

                    b.HasKey("CodigoFuncionario", "CodigoDepartamento");

                    b.HasIndex("CodigoDepartamento");

                    b.ToTable("FuncionarioDepartamentos");
                });

            modelBuilder.Entity("Model.Movimentacao", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CodigoDepartamento");

                    b.Property<int>("CodigoFuncionario");

                    b.Property<DateTime>("DataMovimentacao");

                    b.Property<string>("Descricao")
                        .HasMaxLength(500);

                    b.Property<decimal>("Valor");

                    b.HasKey("Codigo");

                    b.HasIndex("CodigoDepartamento");

                    b.HasIndex("CodigoFuncionario");

                    b.ToTable("Movimentacao");
                });

            modelBuilder.Entity("Model.FuncionarioDepartamentos", b =>
                {
                    b.HasOne("Model.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("CodigoDepartamento")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Model.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("CodigoFuncionario")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.Movimentacao", b =>
                {
                    b.HasOne("Model.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("CodigoDepartamento")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Model.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("CodigoFuncionario")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}