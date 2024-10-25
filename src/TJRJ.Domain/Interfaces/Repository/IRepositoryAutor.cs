using TJRJ.Domain.Entities;

namespace TJRJ.Domain.Interfaces.Repository
{
    public interface IRepositoryAutor : IRepository<Autor>
    {
        Task<Autor> BuscarAutorPorId(int id);
    }
}
