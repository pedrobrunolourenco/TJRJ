using TJRJ.Domain.Entities;

namespace TJRJ.Domain.Interfaces.Service
{
    public interface IServiceAutor
    {
        Task<IEnumerable<Autor>> ObterAutores();
        Task<Autor> ObterAutorPorId(int id);
        Task<Autor> IncluirAutor(Autor autor);
        Task<Autor> AlterarAutor(int CodAu, Autor autor);
        Task<Autor> ExcluirAutor(int CodAu);
    }
}
