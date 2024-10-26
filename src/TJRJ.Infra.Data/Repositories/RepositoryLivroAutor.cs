using Microsoft.EntityFrameworkCore;
using TJRJ.Domain.Entities;
using TJRJ.Domain.Interfaces.Repository;

namespace TJRJ.Infra.Data.Repositories
{
    public class RepositoryLivroAutor : Repository<Livro_Autor>, IRepositoryLivroAutor
    {
        private readonly DataContext _context;

        public RepositoryLivroAutor(DataContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> DeletarLivroAutor(int id_livro)
        {
            var autoresParaDeletar = _context.Livro_Autor
                    .Where(l => l.Livro_CodI == id_livro)
                    .ToList();

            _context.Livro_Autor.RemoveRange(autoresParaDeletar);

            return true;

        }
    }
}
