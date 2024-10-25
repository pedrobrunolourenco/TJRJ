using Microsoft.EntityFrameworkCore;
using TJRJ.Domain.Entities;
using TJRJ.Domain.Interfaces.Repository;

namespace TJRJ.Infra.Data.Repositories
{
    public class RepositoryAutor : Repository<Autor>, IRepositoryAutor
    {

        private readonly DataContext _context;

        public RepositoryAutor(DataContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Autor> BuscarAutorPorId(int id)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(e => e.CodAu == id);
        }


    }
}
