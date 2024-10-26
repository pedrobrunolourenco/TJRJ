using TJRJ.Domain.Entities;

namespace TJRJ.Domain.Interfaces.Repository
{
    public interface IRepositoryLivroAssunto : IRepository<Livro_Assunto>
    {
        Task<bool> DeletarLivroAssunto(int id_livro);
    }
}
