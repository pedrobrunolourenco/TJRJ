using Microsoft.EntityFrameworkCore;
using TJRJ.Domain.Entities;
using TJRJ.Domain.Interfaces.Repository;

namespace TJRJ.Infra.Data.Repositories
{
    public class RepositoryLivro : Repository<Livro>, IRepositoryLivro
    {

        private readonly DataContext _context;

        public RepositoryLivro(DataContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Livro> BuscarLivroPorId(int id)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(e => e.CodI == id);
        }


    }
}
