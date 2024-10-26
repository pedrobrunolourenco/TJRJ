using TJRJ.Domain.Entities;

namespace TJRJ.Domain.Interfaces.Repository
{
    public interface IRepositoryLivroAutor : IRepository<Livro_Autor>
    {
        Task<bool> DeletarLivroAutor(int id_livro);
    }
}
