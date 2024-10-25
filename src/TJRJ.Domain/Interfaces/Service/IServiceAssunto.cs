using TJRJ.Domain.Entities;

namespace TJRJ.Domain.Interfaces.Service
{
    public interface IServiceAssunto 
    {
        Task<IEnumerable<Assunto>> ObterAssuntos();
        Task<Assunto> IncluirAssunto(Assunto assunto);
        Task<Assunto> AlterarAssunto(Assunto assunto);
        Task<Assunto> ExcluirAssunto(int CodAs);

    }
}
