using TJRJ.Domain.Entities;
using TJRJ.Domain.Interfaces.Repository;

namespace TJRJ.Infra.Data.Repositories
{
    public class RepositoryLivroAutor : Repository<Livro_Autor>, IRepositoryLivroAutor
    {
        public RepositoryLivroAutor(DataContext context) : base(context)
        {

        }
    }
}
