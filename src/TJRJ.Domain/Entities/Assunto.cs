using FluentValidation;

namespace TJRJ.Domain.Entities
{
    public class Assunto : Entity
    {

        public Assunto() { }

        public Assunto(int codAs, string descricao)
        {
            CodAs = codAs;
            Descricao = descricao;
            Livro_Assuntos = new List<Livro_Assunto>();
        }

        public int CodAs { get; private set; }
        public string Descricao { get; private set; }

        public ICollection<Livro_Assunto> Livro_Assuntos { get; private set; }

        public void AtriuirCodAs(int codAs)
        {
            CodAs = codAs;
        }

        public void AtriuirDescricao(string descricao)
        {
            Descricao = descricao;
        }

        public override bool Validar()
        {
            ValidationResult = new AssuntoValidation().Validate(this);
            foreach (var erro in ValidationResult.Errors)
            {
                ListaErros.Add(erro.ErrorMessage);
            }
            return ValidationResult.IsValid;
        }

        public class AssuntoValidation : AbstractValidator<Assunto>
        {

            public AssuntoValidation()
            {
                RuleFor(t => t.CodAs)
                     .NotEqual(0)
                     .WithMessage("Código do assunto deve ser maior que zero.");

                RuleFor(t => t.Descricao)
                    .Length(2, 29)
                    .WithMessage("Informe a descrição do assunto com no mínimo 2 e no máximo 20 caracteres.");
            }
        }



    }
}
