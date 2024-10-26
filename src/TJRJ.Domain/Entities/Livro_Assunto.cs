using FluentValidation;

namespace TJRJ.Domain.Entities
{
    public class Livro_Assunto : Entity
    {
        public Livro_Assunto() { }

        public Livro_Assunto(int livro_Codi, int assunto_CodAs)
        {
            Livro_CodI = livro_Codi;
            Assunto_CodAs = assunto_CodAs;
        }

        public int Livro_CodI { get; private set; }
        public int Assunto_CodAs { get; private set; }

        public Assunto Assunto { get; set; }


        public override bool Validar()
        {
            ValidationResult = new Livro_AssuntoValidation().Validate(this);
            foreach (var erro in ValidationResult.Errors)
            {
                ListaErros.Add(erro.ErrorMessage);
            }
            return ValidationResult.IsValid;
        }

        public class Livro_AssuntoValidation : AbstractValidator<Livro_Assunto>
        {

            public Livro_AssuntoValidation()
            {
                RuleFor(t => t.Livro_CodI)
                     .GreaterThan(0)
                     .WithMessage("Código do livro deve ser maior que zero.");

                RuleFor(t => t.Assunto_CodAs)
                     .GreaterThan(0)
                     .WithMessage("Código do assunto deve ser maior que zero.");
            }
        }

    }
}
