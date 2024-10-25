using TJRJ.Domain.Entities;

namespace TJRJ.Domain.Interfaces.Service
{
    public interface IServiceAutor
    {
        Task<IEnumerable<Autor>> ObterAutores();
        Task<Assunto> IncluirAutor(Autor autor);
        Task<Assunto> AlterarAutor(int CodAu, Autor autor);
        Task<Assunto> ExcluirAutor(int CodAu);
    }
}
