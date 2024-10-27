using TJRJ.Domain.DTOs;
using TJRJ.Domain.Interfaces.Repository;

namespace TJRJ.Domain.Queries
{
    public class LivroQuery : ILivroQuery
    {

        private readonly IRepositoryLivro _repositoryLivro;

        public LivroQuery(IRepositoryLivro repositoryLivro)
        {
            _repositoryLivro = repositoryLivro;
        }

        public async Task<IEnumerable<AssuntoDto>> ObterAssuntosDoLivro(int codLivro)
        {
            return await _repositoryLivro.ObterAssuntosDoLivro(codLivro);
        }

        public async Task<IEnumerable<AutorDto>> ObterAutoresDoLivro(int codLivro)
        {
            return await _repositoryLivro.ObterAutoresDoLivro(codLivro);
        }

        public async Task<LivroDto> ObterLivroPorId(int codLivro)
        {
            return await _repositoryLivro.ObterLivroPorId(codLivro);
        }

        public async Task<IEnumerable<LivroDto>> ObterTodosOsLivros()
        {
            return await _repositoryLivro.ObterTodosOsLivros();
        }
    }
}
