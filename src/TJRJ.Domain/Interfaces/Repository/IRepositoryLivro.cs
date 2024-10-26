using TJRJ.Domain.Entities;

namespace TJRJ.Domain.Interfaces.Repository
{
    public interface IRepositoryLivro : IRepository<Livro>
    {
        Task<Livro> BuscarLivroPorId(int id);
    }
}
