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
            builder.Property(l => l.Titulo).IsRequired().HasColumnType("varchar").HasMaxLength(40);
            builder.Property(l => l.Editora).IsRequired().HasColumnType("varchar").HasMaxLength(40);
            builder.Property(l => l.Edicao).IsRequired().HasColumnType("int");
            builder.Property(l => l.AnoPublicacao).IsRequired().HasColumnType("varchar").HasMaxLength(4);
            builder.Ignore(p => p.ListaErros);
            builder.Ignore(p => p.ValidationResult);


            // Configuração o relacionamento 1:N livro -> livro_autor
            builder.HasMany(l => l.LivrosAutores)
                   .WithOne()
                   .HasForeignKey(la => la.Livro_CodI)
                   .OnDelete(DeleteBehavior.Restrict);

            // Configuração do relacionamento 1:N livro -> livro_assunto
            builder.HasMany(l => l.LivroAssuntos)
                   .WithOne(l => l.Livro)
                   .HasForeignKey(la => la.Livro_CodI)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.ToTable("Livro");
        }
    }
}
