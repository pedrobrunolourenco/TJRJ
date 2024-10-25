﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TJRJ.Domain.Entities;

namespace TJRJ.Infra.Data.Mappings
{
    public class Livro_AutorMapping : IEntityTypeConfiguration<Livro_Autor>
    {
        public void Configure(EntityTypeBuilder<Livro_Autor> builder)
        {
            builder.HasKey(l => new { l.Livro_CodI, l.Autor_CodAu });

            builder.Property(l => l.Livro_CodI)
                   .IsRequired()
                   .HasColumnType("int");

            builder.Property(l => l.Autor_CodAu)
                   .IsRequired()
                   .HasColumnType("int");

            // 1 registro de livro_autor tem 1 autor
            builder.HasOne(l => l.Autor)
                   .WithMany(a => a.Livro_Autores)
                   .HasForeignKey(l => l.Autor_CodAu);


            builder.Ignore(l => l.ListaErros);
            builder.Ignore(l => l.ValidationResult);

            builder.ToTable("Livro_Autor");
       }

    }
}