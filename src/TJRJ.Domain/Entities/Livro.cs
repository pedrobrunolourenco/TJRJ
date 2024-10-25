using FluentValidation;

namespace TJRJ.Domain.Entities
{
    public class Livro : Entity
    {
        public Livro() { }

        public Livro(int codI, string titulo, string editora, int edicao, string anoPublicacao)
        {
            CodI = codI;
            Titulo = titulo;
            Editora = editora;
            Edicao = edicao;
            AnoPublicacao = anoPublicacao;
        }

        public int CodI { get; private set; }
        public string Titulo { get; private set; }
        public string Editora { get; private set; }
        public int Edicao { get; private set; }
        public string AnoPublicacao { get; private set; }


        public override bool Validar()
        {
            ValidationResult = new LivroValidation().Validate(this);
            foreach (var erro in ValidationResult.Errors)
            {
                ListaErros.Add(erro.ErrorMessage);
            }
            return ValidationResult.IsValid;
        }

        public class LivroValidation : AbstractValidator<Livro>
        {

            public LivroValidation()
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
}
