using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TJRJ.Domain.Entities;

namespace TJRJ.Infra.Data.Mappings
{
    public class Livro_AssuntoMapping : IEntityTypeConfiguration<Livro_Assunto>
    {
        public void Configure(EntityTypeBuilder<Livro_Assunto> builder)
        {
            builder.HasKey(l => new { l.Livro_CodI, l.Assunto_CodAs });

            builder.Property(l => l.Livro_CodI)
                   .ValueGeneratedNever()
                   .IsRequired()
                   .HasColumnType("int");

            builder.Property(l => l.Assunto_CodAs)
                   .ValueGeneratedNever()
                   .IsRequired()
                   .HasColumnType("int");

            // um registro de livro_assunto tem 1 assunto 
            builder.HasOne(l => l.Assunto)
                   .WithMany(a => a.Livro_Assuntos)
                   .HasForeignKey(l => l.Assunto_CodAs);


            builder.Ignore(l => l.ListaErros);
            builder.Ignore(l => l.ValidationResult);


            builder.ToTable("Livro_Assunto");
        }


    }
}
