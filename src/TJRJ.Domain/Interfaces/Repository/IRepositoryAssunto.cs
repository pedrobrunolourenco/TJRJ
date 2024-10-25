using TJRJ.Domain.Entities;

namespace TJRJ.Domain.Interfaces.Repository
{
    public interface IRepositoryAssunto : IRepository<Assunto>
    {
        Task<Assunto> BuscarAssuntoPorId(int id);

    }
}
