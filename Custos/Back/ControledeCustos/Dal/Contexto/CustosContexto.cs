using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dal
{
    public class CustosContexto : DbContext
    {
        public virtual DbSet<Funcionario> Funcionario { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Movimentacao> Movimentacao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-MHLLB5T\SQLEXPRESS;Initial Catalog=Custos;User ID=sa;Password=sa2012ce;pooling=false;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Funcionario>(entity =>
            //{
            //    entity.HasMany(s => s.Departamentos)
            //   .WithOne(c => c.Funcionario);
            //});

            modelBuilder.Entity<Movimentacao>(entity =>
            {
                entity.HasOne(d => d.Funcionario)
                    .WithMany()
                    .HasForeignKey(d => d.CodigoFuncionario);

                entity.HasOne(d => d.Departamento)
                    .WithMany()
                    .HasForeignKey(d => d.CodigoDepartamento);
            });

            modelBuilder.Entity<FuncionarioDepartamentos>(entity =>
            {
                entity.HasKey(o => new { o.CodigoFuncionario, o.CodigoDepartamento });

                entity.HasOne(d => d.Funcionario)
                    .WithMany()
                    .HasForeignKey(d => d.CodigoFuncionario);

                entity.HasOne(d => d.Departamento)
                    .WithMany()
                    .HasForeignKey(d => d.CodigoDepartamento);
            });
            


        }

    }
}
