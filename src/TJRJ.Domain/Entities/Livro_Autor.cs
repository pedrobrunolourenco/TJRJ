using FluentValidation;

namespace TJRJ.Domain.Entities
{
    public class Livro_Autor : Entity
    {

        public Livro_Autor() { }

        public Livro_Autor(int livro_CodI, int autor_CodAu)
        {
            Livro_CodI = livro_CodI;
            Autor_CodAu = autor_CodAu;
        }

        public int Livro_CodI { get; private set; }
        public int Autor_CodAu { get; private set; }

        // Propriedades de navegação
        public Autor Autor { get; private set; }
        public Livro Livro { get; private set; }



        public override bool Validar()
        {
            ValidationResult = new Livro_AutorValidation().Validate(this);
            foreach (var erro in ValidationResult.Errors)
            {
                ListaErros.Add(erro.ErrorMessage);
            }
            return ValidationResult.IsValid;
        }

        public class Livro_AutorValidation : AbstractValidator<Livro_Autor>
        {

            public Livro_AutorValidation()
            {
                RuleFor(t => t.Livro_CodI)
                     .GreaterThan(0)
                     .WithMessage("Código do livro deve ser maior que zero.");

                RuleFor(t => t.Autor_CodAu)
                     .GreaterThan(0)
                     .WithMessage("Código do autor deve ser maior que zero.");
            }
        }
    }
}
