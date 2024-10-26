using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TJRJ.Domain.Entities;

namespace TJRJ.Infra.Data.Mappings
{
    public class LivroMapping : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.HasKey(l => new { l.CodI });

            builder.Property(l => l.CodI)
                   .ValueGeneratedNever()
                   .IsRequired()
                   .HasColumnType("int");

            builder.Property(l => l.Titulo).IsRequired().HasColumnType("varchar").HasMaxLength(40);
            builder.Property(l => l.Editora).IsRequired().HasColumnType("varchar").HasMaxLength(40);
            builder.Property(l => l.Edicao).IsRequired().HasColumnType("int");
            builder.Property(l => l.AnoPublicacao).IsRequired().HasColumnType("varchar").HasMaxLength(4);

            builder.Ignore(p => p.ListaErros);
            builder.Ignore(p => p.ValidationResult);



            builder.HasMany<Livro_Assunto>()
                               .WithOne() // Não especificamos uma propriedade de navegação
                               .HasForeignKey(la => la.Livro_CodI) // Chave estrangeira na entidade LivroAssunto
                               .OnDelete(DeleteBehavior.Restrict);

            // Configurando relacionamento 1:N com LivroAutor
            builder.HasMany<Livro_Autor>()
                   .WithOne() // Não especificamos uma propriedade de navegação
                   .HasForeignKey(la => la.Livro_CodI) // Chave estrangeira na entidade LivroAutor
                   .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Livro");
        }
    }
}
