
using FluentValidation;


namespace TJRJ.Domain.Entities
{
    public class Autor : Entity
    {

        public Autor() { }

        public Autor(int codAu, string nome)
        {
            CodAu = codAu;
            Nome = nome;
            Livro_Autores = new List<Livro_Autor>();
        }

        public int CodAu { get; private set; }
        public string Nome { get; private set; }


        // Coleção de Livro_Autor
        public ICollection<Livro_Autor> Livro_Autores { get; private set; }


        public override bool Validar()
        {
            ValidationResult = new AutorValidation().Validate(this);
            foreach (var erro in ValidationResult.Errors)
            {
                ListaErros.Add(erro.ErrorMessage);
            }
            return ValidationResult.IsValid;
        }

        public class AutorValidation : AbstractValidator<Autor>
        {

            public AutorValidation()
            {
                RuleFor(t => t.CodAu)
                     .GreaterThan(0)
                     .WithMessage("Código do autor deve ser maior que zero.");

                RuleFor(t => t.Nome)
                    .Length(2, 40)
                    .WithMessage("Informe o nome do autor com no mínimo 2 e no máximo 40 caracteres.");
            }
        }

    }
}
