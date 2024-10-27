using FluentValidation;
using TJRJ.Domain.Core.Messages;

namespace TJRJ.Domain.Commands
{
    public class AdicionarAutorCommand : Command
    {
        public int Livro_CodI { get; private set; }
        public int Autor_CodAu { get; private set; }

        public AdicionarAutorCommand(int livro_CodI, int autor_CodAu)
        {
            Livro_CodI = livro_CodI;
            Autor_CodAu = autor_CodAu;
            AggregateId = livro_CodI;
        }

    }

    public class AdicionarAutorCommandValidation : AbstractValidator<AdicionarAutorCommand>
    {

        public AdicionarAutorCommandValidation()
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
