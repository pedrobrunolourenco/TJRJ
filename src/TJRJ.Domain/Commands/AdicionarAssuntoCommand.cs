using FluentValidation;
using TJRJ.Domain.Core.Messages;

namespace TJRJ.Domain.Commands
{
    public class AdicionarAssuntoCommand : Command
    {
        public int Livro_CodI { get; private set; }
        public int Assunto_CodAs { get; private set; }


        public AdicionarAssuntoCommand(int livro_CodI, int assunto_CodAs)
        {
            Livro_CodI = livro_CodI;
            Assunto_CodAs = assunto_CodAs;
            AggregateId = livro_CodI;
        }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarAssuntoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }


    }

    public class AdicionarAssuntoCommandValidation : AbstractValidator<AdicionarAssuntoCommand>
    {

        public AdicionarAssuntoCommandValidation()
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
