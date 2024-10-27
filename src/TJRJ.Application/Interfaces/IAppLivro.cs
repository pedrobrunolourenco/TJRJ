using TJRJ.Application.Model;
using TJRJ.Domain.DTOs;

namespace TJRJ.Application.Interfaces
{
    public interface IAppLivro
    {
        Task<LivroRetornoModel> IncluirLivro(LivroModel livro);
        Task<LivroRetornoModel> AlterarLivro(LivroAlteracaoModel livro);
        Task<LivroRetornoModel> ExcluirLivro(int codLivro);
        Task<LivroAutorRetornoModel> IncluirAutor(LivroAutorModel livroAutor);

        Task<IEnumerable<LivroDto>> ObterTodosOsLivros();
        Task<LivroDto> ObterLivroPorId(int codLivro);

    }
}
