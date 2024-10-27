using TJRJ.Domain.DTOs;

namespace TJRJ.Domain.Queries
{
    public interface ILivroQuery
    {
        Task<IEnumerable<LivroDto>> ObterTodosOsLivros();
    }
}
