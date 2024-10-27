using TJRJ.Domain.DTOs;
using TJRJ.Domain.Entities;

namespace TJRJ.Domain.Interfaces.Repository
{
    public interface IRepositoryLivro : IRepository<Livro>
    {
        Task<Livro> BuscarLivroPorId(int id);
        Task<IEnumerable<LivroDto>> ObterTodosOsLivros();
        Task<LivroDto> ObterLivroPorId(int codId);
    }
}
