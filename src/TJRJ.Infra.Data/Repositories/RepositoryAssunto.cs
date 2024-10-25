using TJRJ.Domain.Entities;
using TJRJ.Domain.Interfaces.Repository;

namespace TJRJ.Infra.Data.Repositories
{
    public class RepositoryAssunto : Repository<Assunto>, IRepositoryAssunto
    {
        public RepositoryAssunto(DataContext context) : base(context)
        {

        }
    }
}
