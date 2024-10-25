using TJRJ.Domain.Entities;
using TJRJ.Domain.Interfaces.Repository;

namespace TJRJ.Infra.Data.Repositories
{
    public class RepositoryAutor : Repository<Autor>, IRepositoryAutor
    {
        public RepositoryAutor(DataContext context) : base(context)
        {

        }
    }
}
