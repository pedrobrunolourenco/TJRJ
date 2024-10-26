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

            builder.HasOne<Livro>() // Indica que o relacionamento é com a entidade Livro
                   .WithMany() // Sem propriedade de navegação na classe Livro
                   .HasForeignKey(la => la.Livro_CodI) // Define a chave estrangeira
                   .OnDelete(DeleteBehavior.Restrict); // Comportamento em caso de deleção

            // Relacionamento com Assunto
            builder.HasOne(l => l.Assunto)
                   .WithMany(a => a.Livro_Assuntos)
                   .HasForeignKey(la => la.Assunto_CodAs);

            // Ignora propriedades que não devem ser mapeadas
            builder.Ignore(l => l.ListaErros);
            builder.Ignore(l => l.ValidationResult);

            builder.ToTable("Livro_Assunto");
        }


    }
}
