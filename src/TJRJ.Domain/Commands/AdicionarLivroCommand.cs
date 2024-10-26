using FluentValidation;
using TJRJ.Domain.Core.Messages;

namespace TJRJ.Domain.Commands
{
    public class AdicionarLivroCommand : Command
    {
        public int CodI { get; private set; }
        public string Titulo { get; private set; }
        public string Editora { get; private set; }
        public int Edicao { get; private set; }
        public string AnoPublicacao { get; private set; }
        public int CodigoAssunto { get; private set; }
        public int CodigoAutor { get; private set; }


        public AdicionarLivroCommand(int codI, string titulo, string editora, int edicao, string anoPublicacao, int codigoAssunto, int codigoAutor)
        {
            CodI = codI;
            Titulo = titulo;
            Editora = editora;
            Edicao = edicao;
            AnoPublicacao = anoPublicacao;
            CodigoAssunto = codigoAssunto;
            CodigoAutor = codigoAutor;
        }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarLivroCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }

    public class AdicionarLivroCommandValidation : AbstractValidator<AdicionarLivroCommand>
    {

        public AdicionarLivroCommandValidation()
        {
            RuleFor(t => t.CodI)
                 .GreaterThan(0)
                 .WithMessage("Código do livro deve ser maior que zero.");

            RuleFor(t => t.Titulo)
                .Length(1, 40)
                .WithMessage("Informe o título com no mínimo 1 e no máximo 40 caracteres.");

            RuleFor(t => t.Editora)
                .Length(1, 40)
                .WithMessage("Informe a editora com no mínimo 1 e no máximo 40 caracteres.");

            RuleFor(t => t.Edicao)
                 .GreaterThan(0)
                 .WithMessage("O número da edição deve ser maior que zero.");

            RuleFor(t => t.AnoPublicacao)
                .NotEmpty().WithMessage("Ano de publicação é obrigatório.")
                .Matches(@"^\d{4}$").WithMessage("Ano de publicação deve conter exatamente 4 dígitos.")
                .Must(ValidaAnoPublicacao).WithMessage("Ano de publicação não pode ser maior que o ano corrente.");

            RuleFor(t => t.CodigoAssunto)
                .GreaterThan(0)
                .WithMessage("O código do assunto deve ser maior que zero.");

            RuleFor(t => t.CodigoAutor)
                .GreaterThan(0)
                .WithMessage("O código do autor deve ser maior que zero.");


        }

        private bool ValidaAnoPublicacao(string ano)
        {
            if (int.TryParse(ano, out int anoInt))
            {
                return anoInt <= DateTime.Now.Year;
            }
            return false;
        }
    }

}
