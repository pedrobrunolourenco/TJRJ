using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TJRJ.Domain.Entities;

namespace TJRJ.Infra.Data.Mappings
{
    public class AssuntoMapping : IEntityTypeConfiguration<Assunto>
    {

        public void Configure(EntityTypeBuilder<Assunto> builder)
        {
            builder.HasKey(a => new { a.CodAs });

            builder.Property(a => a.CodAs)
                   .IsRequired()
                   .ValueGeneratedNever()
                   .HasColumnType("int");

            builder.Property(a => a.Descricao).IsRequired().HasColumnType("varchar").HasMaxLength(20);



            builder.Ignore(a => a.ListaErros);
            builder.Ignore(a => a.ValidationResult);

            builder.ToTable("Assunto");
        }

    }
}
