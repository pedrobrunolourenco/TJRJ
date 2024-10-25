using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TJRJ.Domain.Entities;

namespace TJRJ.Infra.Data.Mappings
{
    public class AutorMapping : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.HasKey(a => new { a.CodAu });

            builder.Property(a => a.CodAu )
                   .IsRequired()
                   .HasColumnType("int");

            builder.Property(a => a.Nome).IsRequired().HasColumnType("varchar").HasMaxLength(40);



            builder.Ignore(a => a.ListaErros);
            builder.Ignore(a => a.ValidationResult);

            builder.ToTable("Autor");
        }

    }
}
