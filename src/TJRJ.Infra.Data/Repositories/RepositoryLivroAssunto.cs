using TJRJ.Domain.Entities;
using TJRJ.Domain.Interfaces.Repository;

namespace TJRJ.Infra.Data.Repositories
{
    public class RepositoryLivroAssunto : Repository<Livro_Assunto>, IRepositoryLivroAssunto
    {
        public RepositoryLivroAssunto(DataContext context) : base(context)
        {

        }
    }
}
