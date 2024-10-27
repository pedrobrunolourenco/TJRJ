using TJRJ.Domain.Entities;
using TJRJ.Domain.Interfaces.Repository;

namespace TJRJ.Infra.Data.Repositories
{
    public class RepositoryLivroAssunto : Repository<Livro_Assunto>, IRepositoryLivroAssunto
    {
        private readonly DataContext _context;

        public RepositoryLivroAssunto(DataContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> DeletarLivroAssunto(int id_livro)
        {
            var assuntosParaDeletar = _context.Livro_Assunto
                    .Where(l => l.Livro_CodI == id_livro) 
                    .ToList();

            _context.Livro_Assunto.RemoveRange(assuntosParaDeletar);

            return true;
        }
    }
}
