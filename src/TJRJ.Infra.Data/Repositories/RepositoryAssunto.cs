using Microsoft.EntityFrameworkCore;
using TJRJ.Domain.Entities;
using TJRJ.Domain.Interfaces.Repository;

namespace TJRJ.Infra.Data.Repositories
{
    public class RepositoryAssunto : Repository<Assunto>, IRepositoryAssunto
    {
        private readonly DataContext _context;

        public RepositoryAssunto(DataContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Assunto> BuscarAssuntoPorId(int id)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(e => e.CodAs == id);
        }

    }
}
