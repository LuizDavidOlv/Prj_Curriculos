using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mappings
{
    public class FormacaoMapping : IEntityTypeConfiguration<Formacao>
    {
        public void Configure(EntityTypeBuilder<Formacao> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(f => f.Curso)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(f => f.Status)
                .IsRequired()
                .HasColumnType("int");

            builder.Property(f => f.DataConclusao)
                .IsRequired()
                .HasColumnType("date");


            builder.ToTable("Formacoes");
        }
    }
}
